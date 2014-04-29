using System;
using System.IO;
using System.Collections.Generic;
class RoomSign{
 Dictionary<string, Room> roomSign = new Dictionary<string, Room>();

 public RoomSign(string entryInfo, string courseCode){
     PeriodEntries pe = new PeriodEntries(entryInfo, courseCode);
	 organize(pe.getEntryList());
     
 }
	
 
 public Room getRoom(string roomNumber)
 {
     if (roomSign.ContainsKey(roomNumber))
         return roomSign[roomNumber];
	 return null;
 }

 public Dictionary<string, Room> getAll()
 {
     return roomSign;
 }

 public void organize(List<Entry> entrys){ //go through all entrys and sorts them into their rooms
  for(int index = 0; index < entrys.Count; index++){
   if(roomSign.ContainsKey(entrys[index].getRoom()))
    roomSign[entrys[index].getRoom()].addEntry(entrys[index]); //addentry sorts entrys by period
   else{ //adds a new entry
    roomSign.Add(entrys[index].getRoom(), new Room(entrys[index].getRoom()));
	//Console.WriteLine(entrys[index].getRoom());
    roomSign[entrys[index].getRoom()].addEntry(entrys[index]);
	
	}
  }
 }
}