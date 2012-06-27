﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using OpenDentBusiness;
using System.Windows.Forms;
using CodeBase;

namespace OpenDental {
	public class PrefL{

		///<summary>This ONLY runs when first opening the program.  It returns true if either no conversion is necessary, or if conversion was successful.  False for other situations like corrupt db, trying to convert to older version, etc.  Silent mode is ONLY used for internal tools, NEVER with the main program.</summary>
		public static bool ConvertDB(bool silent,string toVersion) {
			ClassConvertDatabase ClassConvertDatabase2=new ClassConvertDatabase();
			string pref=PrefC.GetString(PrefName.DataBaseVersion);
				//(Pref)PrefC.HList["DataBaseVersion"];
			//Debug.WriteLine(pref.PrefName+","+pref.ValueString);
			if(ClassConvertDatabase2.Convert(pref,toVersion,silent)) {
				//((Pref)PrefC.HList["DataBaseVersion"]).ValueString)) {
				return true;
			}
			else {
				Application.Exit();
				return false;
			}
		}

		///<summary>This ONLY runs when first opening the program.  It returns true if either no conversion is necessary, or if conversion was successful.  False for other situations like corrupt db, trying to convert to older version, etc.</summary>
		public static bool ConvertDB() {
			return ConvertDB(false,Application.ProductVersion);
		}

		public static bool CopyFromHereToUpdateFiles(Version currentVersion) {
			if(!PrefC.UsingAtoZfolder) {
				return true;//not using AtoZ, so no place to stash the files.
			}
			string folderUpdate=ODFileUtils.CombinePaths(ImageStore.GetPreferredAtoZpath(),"UpdateFiles");
			if(Directory.Exists(folderUpdate)) {
				try {
					Directory.Delete(folderUpdate,true);
				}
				catch {
					MessageBox.Show(Lan.g("Prefs","Please delete this folder and then re-open the program: ")+folderUpdate);
					return false;
				}
				//wait a bit so that CreateDirectory won't malfunction.
				DateTime now=DateTime.Now;
				while(Directory.Exists(folderUpdate) && DateTime.Now < now.AddSeconds(10)) {//up to 10 seconds
					Application.DoEvents();
				}
				if(Directory.Exists(folderUpdate)) {
					MessageBox.Show(Lan.g("Prefs","Please delete this folder and then re-open the program: ")+folderUpdate);
					return false;
				}
			}
			Directory.CreateDirectory(folderUpdate);
			DirectoryInfo dirInfo=new DirectoryInfo(Application.StartupPath);
			FileInfo[] appfiles=dirInfo.GetFiles();
			for(int i=0;i<appfiles.Length;i++) {
				if(appfiles[i].Name=="FreeDentalConfig.xml") {
					continue;//skip this one.
				}
				if(appfiles[i].Name=="OpenDentalServerConfig.xml") {
					continue;//skip also
				}
				if(appfiles[i].Name.StartsWith("openlog")) {
					continue;//these can be big and are irrelevant
				}
				if(appfiles[i].Name.Contains("__")) {//double underscore
					continue;//So that plugin dlls can purposely skip the file copy.
				}
				//include UpdateFileCopier
				File.Copy(appfiles[i].FullName,ODFileUtils.CombinePaths(folderUpdate,appfiles[i].Name));
			}
			//Create a simple manifest file so that we know what version the files are for.
			File.WriteAllText(ODFileUtils.CombinePaths(folderUpdate,"Manifest.txt"),currentVersion.ToString(3));
			return true;
		}

		///<summary>Called in two places.  Once from FormOpenDental.PrefsStartup, and also from FormBackups after a restore.</summary>
		public static bool CheckProgramVersion() {
			if(PrefC.GetBool(PrefName.UpdateWindowShowsClassicView)) {
				return CheckProgramVersionClassic();
			}
			Version storedVersion=new Version(PrefC.GetString(PrefName.ProgramVersion));
			Version currentVersion=new Version(Application.ProductVersion);
			string database="";
			//string command="";
			if(DataConnection.DBtype==DatabaseType.MySql){
				database=MiscData.GetCurrentDatabase();
			}
			if(storedVersion<currentVersion) {
				//There are two different situations where this might happen.
				if(PrefC.GetString(PrefName.UpdateInProgressOnComputerName)==""){//1. Just performed an update from this workstation on another database.
					//This is very common for admins when viewing slighly older databases.
					//There should be no annoying behavior here.  So do nothing.
					#if !DEBUG
						//Excluding this in debug allows us to view slightly older databases without accidentally altering them.
						Prefs.UpdateString(PrefName.ProgramVersion,currentVersion.ToString());
						Cache.Refresh(InvalidType.Prefs);
					#endif
					return true;
				}
				//and 2a. Just performed an update from this workstation on this database.  
				//or 2b. Just performed an update from this workstation for multiple databases.
				//In both 2a and 2b, we already downloaded Setup file to correct location for this db, so skip 1 above.
				//This computer just performed an update, but none of the other computers has updated yet.
				//So attempt to stash all files that are in the Application directory.
				if(!CopyFromHereToUpdateFiles(currentVersion)) {
					Application.Exit();
					return false;
				}
				Prefs.UpdateString(PrefName.ProgramVersion,currentVersion.ToString());
				Prefs.UpdateString(PrefName.UpdateInProgressOnComputerName,"");//now, other workstations will be allowed to update.
				Cache.Refresh(InvalidType.Prefs);
			}
			if(storedVersion>currentVersion) {
				//This is the update sequence for both a direct workstation, and for a ClientWeb workstation.
				if(!PrefC.UsingAtoZfolder){//Not using image path.
					//this does not bypass checking the RegistrationKey because that's the only way to get the UpdateCode.
					//perform program update automatically.
					DownloadAndRunSetup(storedVersion,currentVersion);
					Application.Exit();
					return false;
				}
				string folderUpdate=ODFileUtils.CombinePaths(ImageStore.GetPreferredAtoZpath(),"UpdateFiles");
				//look at the manifest to see if it's the version we need
				string manifestVersion="";
				try {
					manifestVersion=File.ReadAllText(ODFileUtils.CombinePaths(folderUpdate,"Manifest.txt"));
				}
				catch {
					//fail silently
				}
				if(manifestVersion!=storedVersion.ToString(3)) {//manifest version is wrong
					//No point trying the Setup.exe because that's probably wrong too.
					//Just go straight to downloading and running the Setup.exe.
					string manpath=ODFileUtils.CombinePaths(folderUpdate,"Manifest.txt");
					if(MessageBox.Show(Lan.g("Prefs","The expected version information was not found in this file: ")+manpath+".  "
						+Lan.g("Prefs","There is probably a permission issue on that folder which should be fixed. ")
						+"\r\n\r\n"+Lan.g("Prefs","The suggested solution is to return to the computer where the update was just run.  Go to Help | Update | Setup, and click the Recopy button.")
						+"\r\n\r\n"+Lan.g("Prefs","If, instead, you click OK in this window, then a fresh Setup file will be downloaded and run."),						
						"",MessageBoxButtons.OKCancel)!=DialogResult.OK)//they don't want to download again.
					{
						Application.Exit();
						return false;
					}
					DownloadAndRunSetup(storedVersion,currentVersion);
					Application.Exit();
					return false;
				}
				//manifest version matches
				if(MessageBox.Show(Lan.g("Prefs","Files will now be copied.")+"\r\n"
					+Lan.g("Prefs","Workstation version will be updated from ")+currentVersion.ToString(3)
					+Lan.g("Prefs"," to ")+storedVersion.ToString(3),
					"",MessageBoxButtons.OKCancel)
					!=DialogResult.OK)//they don't want to update for some reason.
				{
					Application.Exit();
					return false;
				}
				string tempDir=Path.GetTempPath();
				//copy UpdateFileCopier.exe to the temp directory
				File.Copy(ODFileUtils.CombinePaths(folderUpdate,"UpdateFileCopier.exe"),//source
					ODFileUtils.CombinePaths(tempDir,"UpdateFileCopier.exe"),//dest
					true);//overwrite
				//wait a moment to make sure the file was copied
				Thread.Sleep(500);
				//launch UpdateFileCopier to copy all files to here.
				int processId=Process.GetCurrentProcess().Id;
				string appDir=Application.StartupPath;
				Process.Start(ODFileUtils.CombinePaths(tempDir,"UpdateFileCopier.exe"),
					"\""+folderUpdate+"\""//pass the source directory to the file copier.
					+" "+processId.ToString()//and the processId of Open Dental.
					+" \""+appDir+"\"");//and the directory where OD is running
				Application.Exit();//always exits, whether launch of setup worked or not
				return false;
			}
			return true;
		}

		///<summary>If AtoZ.manifest was wrong, or if user is not using AtoZ, then just download again.  Will use dir selected by user.  If an appropriate download is not available, it will fail and inform user.</summary>
		private static void DownloadAndRunSetup(Version storedVersion,Version currentVersion) {
			string patchName="Setup.exe";
			string updateUri=PrefC.GetString(PrefName.UpdateWebsitePath);
			string updateCode=PrefC.GetString(PrefName.UpdateCode);
			string updateInfoMajor="";
			string updateInfoMinor="";
			if(!FormUpdate.ShouldDownloadUpdate(updateUri,updateCode,out updateInfoMajor,out updateInfoMinor)){
				return;
			}
			if(MessageBox.Show(
				Lan.g("Prefs","Setup file will now be downloaded.")+"\r\n"
				+Lan.g("Prefs","Workstation version will be updated from ")+currentVersion.ToString(3)
				+Lan.g("Prefs"," to ")+storedVersion.ToString(3),
				"",MessageBoxButtons.OKCancel)
				!=DialogResult.OK)//they don't want to update for some reason.
			{
				return;
			}
			FolderBrowserDialog dlg=new FolderBrowserDialog();
			dlg.SelectedPath=ImageStore.GetPreferredAtoZpath();
			dlg.Description=Lan.g("Prefs","Setup.exe will be downloaded to the folder you select below");
			if(dlg.ShowDialog()!=DialogResult.OK) {
				return;//app will exit
			}
			string tempFile=ODFileUtils.CombinePaths(dlg.SelectedPath,patchName);
				//ODFileUtils.CombinePaths(Path.GetTempPath(),patchName);
			FormUpdate.DownloadInstallPatchFromURI(updateUri+updateCode+"/"+patchName,//Source URI
				tempFile,true,false,null);//Local destination file.
			File.Delete(tempFile);//Cleanup install file.
		}

		///<summary>This ONLY runs when first opening the program.  Gets run early in the sequence. Returns false if the program should exit.</summary>
		public static bool CheckMySqlVersion() {
			if(DataConnection.DBtype!=DatabaseType.MySql) {
				return true;
			}
			string thisVersion=MiscData.GetMySqlVersion();
			float floatVersion=PIn.Float(thisVersion.Substring(0,3));
			if(floatVersion < 5.0f) {
				//We will force users to upgrade to 5.0, but not yet to 5.5
				MessageBox.Show(Lan.g("Prefs","Your version of MySQL won't work with this program")+": "+thisVersion
					+".  "+Lan.g("Prefs","You should upgrade to MySQL 5.0 using the installer on our website."));
				Application.Exit();
				return false;
			}
			if(!PrefC.ContainsKey("MySqlVersion")) {//db has not yet been updated to store this pref
				//We're going to skip this.  We will recommend that people first upgrade OD, then MySQL, so this won't be an issue.
			}
			else if(Prefs.UpdateString(PrefName.MySqlVersion,floatVersion.ToString("f1"))) {
				if(!MsgBox.Show("Prefs",MsgBoxButtons.OKCancel,"Tables will now be optimized.  This will take a minute or two.")) {
					Application.Exit();
					return false;
				}
				DatabaseMaintenance.RepairAndOptimize();
			}
			if(PrefC.ContainsKey("DatabaseConvertedForMySql41")) {
				return true;//already converted
			}
			if(!MsgBox.Show("Prefs",true,"Your database will now be converted for use with MySQL 4.1.")) {
				Application.Exit();
				return false;
			}
			//ClassConvertDatabase CCD=new ClassConvertDatabase();
			try {
				MiscData.MakeABackup();
			}
			catch(Exception e) {
				if(e.Message!="") {
					MessageBox.Show(e.Message);
				}
				MsgBox.Show("Prefs","Backup failed. Your database has not been altered.");
				Application.Exit();
				return false;//but this should never happen
			}
			MessageBox.Show("Backup performed");
			Prefs.ConvertToMySqlVersion41();
			MessageBox.Show("converted");
			//Refresh();
			return true;
		}

		///<summary>This runs when first opening the program.  If MySql is not at 5.5 or higher, it reminds the user, but does not force them to upgrade.</summary>
		public static void MySqlVersion55Remind(){
			if(DataConnection.DBtype!=DatabaseType.MySql) {
				return;
			}
			string thisVersion=MiscData.GetMySqlVersion();
			float floatVersion=PIn.Float(thisVersion.Substring(0,3));
			//doing it this way will be needed later to handle two digit version numbers.  
			//We may then combine them into a single float, remembering to left pad single digit minor versions.
			//int majVer=int.Parse(thisVersion.Split(',','.')[0]);
			//int minVer=int.Parse(thisVersion.Split(',','.')[1]);
			//if((majVer<5 || (majVer=5 && minVer<5))	&& !Programs.IsEnabled(ProgramName.eClinicalWorks)){//Do not show msg if MySQL version is 5.5 or greater or eCW is enabled
			if(floatVersion < 5.5f	&& !Programs.IsEnabled(ProgramName.eClinicalWorks)){//Do not show msg if MySQL version is 5.5 or greater or eCW is enabled
				MsgBox.Show("Prefs","You should upgrade to MySQL 5.5 using the installer posted on our website.  It's not urgent, but until you upgrade, you are likely to get a few errors each day which will require restarting the MySQL service.");
			}
		}

		///<summary>Essentially no changes have been made to this since version 6.5.</summary>
		private static bool CheckProgramVersionClassic() {
			Version storedVersion=new Version(PrefC.GetString(PrefName.ProgramVersion));
			Version currentVersion=new Version(Application.ProductVersion);
			string database=MiscData.GetCurrentDatabase();
			if(storedVersion<currentVersion) {
				Prefs.UpdateString(PrefName.ProgramVersion,currentVersion.ToString());
				Cache.Refresh(InvalidType.Prefs);
			}
			if(storedVersion>currentVersion) {
				if(PrefC.UsingAtoZfolder) {
					string setupBinPath=ODFileUtils.CombinePaths(ImageStore.GetPreferredAtoZpath(),"Setup.exe");
					if(File.Exists(setupBinPath)) {
						if(MessageBox.Show("You are attempting to run version "+currentVersion.ToString(3)+",\r\n"
							+"But the database "+database+"\r\n"
							+"is already using version "+storedVersion.ToString(3)+".\r\n"
							+"A newer version must have already been installed on at least one computer.\r\n"  
							+"The setup program stored in your A to Z folder will now be launched.\r\n"
							+"Or, if you hit Cancel, then you will have the option to download again."
							,"",MessageBoxButtons.OKCancel)==DialogResult.Cancel) {
							if(MessageBox.Show("Download again?","",MessageBoxButtons.OKCancel)
								==DialogResult.OK) {
								FormUpdate FormU=new FormUpdate();
								FormU.ShowDialog();
							}
							Application.Exit();
							return false;
						}
						try {
							Process.Start(setupBinPath);
						}
						catch {
							MessageBox.Show("Could not launch Setup.exe");
						}
					}
					else if(MessageBox.Show("A newer version has been installed on at least one computer,"+
							"but Setup.exe could not be found in any of the following paths: "+
							ImageStore.GetPreferredAtoZpath()+".  Download again?","",MessageBoxButtons.OKCancel)==DialogResult.OK) {
						FormUpdate FormU=new FormUpdate();
						FormU.ShowDialog();
					}
				}
				else {//Not using image path.
					//perform program update automatically.
					string patchName="Setup.exe";
					string updateUri=PrefC.GetString(PrefName.UpdateWebsitePath);
					string updateCode=PrefC.GetString(PrefName.UpdateCode);
					string updateInfoMajor="";
					string updateInfoMinor="";
					if(FormUpdate.ShouldDownloadUpdate(updateUri,updateCode,out updateInfoMajor,out updateInfoMinor)) {
						if(MessageBox.Show(updateInfoMajor+Lan.g("Prefs","Perform program update now?"),"",
							MessageBoxButtons.YesNo)==DialogResult.Yes) {
							string tempFile=ODFileUtils.CombinePaths(Path.GetTempPath(),patchName);//Resort to a more common temp file name.
							FormUpdate.DownloadInstallPatchFromURI(updateUri+updateCode+"/"+patchName,//Source URI
								tempFile,true,true,null);//Local destination file.
							File.Delete(tempFile);//Cleanup install file.
						}
					}
				}
				Application.Exit();//always exits, whether launch of setup worked or not
				return false;
			}
			return true;
		}

	}
}
