//Check amount of rooms printed
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class driver{
	static RoomSign rs;
	static PeriodEntries pe;
	static string[] time = {"7:14 - 7:59", "8:00 - 8:47", "8:50 - 9:39", "9:42 - 10:29", "10:32 - 11:19", "11:22 - 12:09", "12:12 - 12:59", "1:02 - 1:49", "1:52 - 2:41", "2:44 - 3:31"};
	static StringBuilder schoolsigns = new StringBuilder();
	static string[] taRooms = {"233", "251", "317", "319", "204A", "216B", "328A"};
	
	public static void Main(string[] args){
		string filename;
		/*
		Console.WriteLine("Enter filename with teacher info: ");
		string tp = Console.ReadLine();
		Console.WriteLine("Enter filename with course names: ");
		string cc = Console.ReadLine();
		*/
		string tp = args[0];
		string cc = args[1];
		
		rs = new RoomSign(tp, cc);
		pe = new PeriodEntries(tp, cc);
		schoolsigns.Append(@"<style>
								@media print{.mysign {page-break-after:always;}}
								.rn{font-size:36pt;font-family:calibri;text-align:center;}
								td{border:1px solid black;font-size:14pt;height:50px; }
								table{width:100%;table-layout: fixed;padding-top:0px; padding-bottom:0px;} 
								table.spaceUnder{border-collapse:separate; border-spacing: 0px 10px;}</style>");
        //Console.WriteLine("Enter a room number. Type in -1 to print all.");
        //string roomNumber = Console.ReadLine();
		string roomNumber = args[2];
		filename = roomNumber;
		if(roomNumber == "-1"){
			for(int index = 0; index < getDistinctRooms().Count; index++){
				schoolsigns.Append(createPage(getDistinctRooms()[index]));
				}
			filename  = "All_Room_Schedules";
		}else{
			schoolsigns.Append(createPage(roomNumber));
			schoolsigns.Append(createPage("206"));
			schoolsigns.Append(createPage("208"));
		}
		File.WriteAllText("test.html", schoolsigns.ToString());
		File.WriteAllText("Room 307.doc", schoolsigns.ToString());
		File.WriteAllText("rooms.txt", string.Join("\n",getDistinctRooms().ToArray()));
		//File.WriteAllText(filename + " " + DateTime.Today + ".html", schoolsigns.ToString());
		//File.WriteAllText(filename + " " + DateTime.Today + ".doc", schoolsigns.ToString());
		//getDistinctRooms().ForEach(i => Console.WriteLine(i));
		//foreach(Entry e in entryList)
		//	Console.WriteLine(e.ToString());
		}
		
	public static string createPage(string roomNumber){
		StringBuilder build = new StringBuilder();
		if((!(rs.getAll().ContainsKey(roomNumber))) || taRooms.Any(roomNumber.Contains))
			return "";
        build.Append("<table style='border:5px solid black;align:center;'class='mysign'><tr><td style='height:100%'><table style='table-layout:fixed;overflow:hidden;width:100%;height:90%;' class='spaceUnder'><caption class='rn'><b>Room " + roomNumber + "</b></caption>");
		List<Entry> entryList = rs.getAll()[roomNumber].getentries();
		//Console.WriteLine(entryList.Count);
		
		string teacher, title, code;
		
		for(int period_index = 0; period_index < 10; period_index++)
        {
			//temp = entryList[period_index];
			teacher = "";
			code = "";
			title = "";
            build.Append("<tr style='text-align:center;'>");
			build.Append("<td style='width:250px'>" + "Pd. " + period_index + ": " + time[period_index] + "</td>");
			foreach(Entry e in entryList)
				if(e.getPeriod().Equals(period_index.ToString()) && (e.getcCode().StartsWith("ZYF") || !(e.getcCode().StartsWith("Z")))){
					if(!(teacher.Contains(e.getName())) && !e.getName().StartsWith("L "))
						teacher += e.getName() + " & ";
					title = e.getCTitle();
					code = e.getcCode();
			}
			if(teacher.Length > 2) teacher = teacher.Substring(0,teacher.Length - 2);
			build.Append("<td><b>" + teacher + "</b></td>");
			build.Append("<td style='font-size: 12pt; width: 120px;'>" + title + "<br>" + code + "</td>");
            build.Append("</tr>");
			//Console.WriteLine(temp.getPeriod());
        }
        build.Append("</table></td></tr></table><br clear=all style='mso-special-character:line-break;page-break-before:always'>");	
		return build.ToString();
		/*
		foreach(Entry e in pe.getEntryList())
			if(e.getRoom().Equals("208"))Console.WriteLine(e.ToString());
			
		Console.WriteLine("---------------------------\n");
		foreach(Entry e in rs.getAll()["208"].getentries())
			Console.WriteLine(e.ToString());
		*/
		//Console.WriteLine(rs.getAll()["322"].getentries()[0].ToString());
		//Console.WriteLine(pe.getEntryList()[322].ToString());
		}
		
	public static List<Entry> sort(List<Entry> entryList){
		Entry tmp;
		for(int r = 0; r < entryList.Count; r++){
			for(int c = 0; c < entryList.Count; c++){
				if(entryList[r].getPeriod().CompareTo(entryList[c].getPeriod()) < 0){
					tmp = entryList[r];
					entryList[r] = entryList[c];
					entryList[c] = tmp;
				}
			}
		}
		/*
		Entry[] sortedList = new Entry[10]{new Entry(), new Entry(), new Entry(), new Entry(), new Entry(), new Entry(), new Entry(), new Entry(), new Entry(), new Entry()};
		for(int sort_index = 0; sort_index < entryList.Count; sort_index++){
			sortedList[Convert.ToInt32(entryList[sort_index].getPeriod())] += entryList[sort_index];
			}*/
		return entryList;//sortedList.OfType<Entry>().ToList();
		}
	
	
	public static List<string> getDistinctRooms(){
		List<string> distinctRooms = new List<string>();
		for(int index = 0; index < pe.getEntryList().Count; index++)
			if(!(distinctRooms.Contains(pe.getEntryList()[index].getRoom())))
				distinctRooms.Add(pe.getEntryList()[index].getRoom());
		distinctRooms.Sort();
		return distinctRooms;
		}
		}