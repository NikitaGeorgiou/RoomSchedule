using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class PeriodEntries{
 List<string[]> entryInfo = new List<string[]>(); //raw info from NYCDOE files
 static Dictionary<string, string> cCode = new Dictionary<string, string>(); //NYCDOE course codes, course titles
 List<Entry> entryList = new List<Entry>(); //refined info from entryInfo

 public PeriodEntries(string entryInfo, string courseCode){
  setEntryInfo(entryInfo);
  setCCode(courseCode);
  setEntryList();
 }

 public void setEntryInfo(string eInfo){ //entryInfo is the file name for entry-period csv (file names are similar to )
  using(StreamReader reader = new StreamReader(eInfo)){
   string line;
   while((line = reader.ReadLine()) != null){
    string[] line2 = line.Split(',');
    entryInfo.Add(line2);
   }
  }
 }

 public void setCCode(string courseCode){ //courseCode is the file name of NYCDOE course code csv file ()
  using(StreamReader reader = new StreamReader(courseCode)){
   string line;
   while((line = reader.ReadLine()) != null){
    string[] line2 = line.Split(',');
	if(!cCode.ContainsKey(line2[0]))
		cCode.Add(line2[0], line2[1]);
   }
  }
 }

 public void setEntryList(){ //this area could be broken up. testing for cCode may need an else
  for(int index = 1; index < entryInfo.Count; index++){
   if(cCode.ContainsKey(entryInfo[index][2])){
    entryInfo[index][0] = cCode[entryInfo[index][2]];
    entryList.Add(new Entry(entryInfo[index][9], entryInfo[index][5], entryInfo[index][10], entryInfo[index][2], entryInfo[index][0]));
   }
  }
 }

 
 public List<Entry> getEntryList(){
  return entryList;
 }
 
 }
 