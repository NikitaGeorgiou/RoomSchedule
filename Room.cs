using System;
using System.IO;
using System.Collections.Generic;

class Room{
 string roomNumber;
 List<Entry> entries = new List<Entry>();

 public Room(string roomNumber){ this.roomNumber = roomNumber; }

 public string getRoomNumber(){ return roomNumber; }
 public void setRoomNumber(string roomNumber){ this.roomNumber = roomNumber; }
 public List<Entry> getentries(){ return entries; }

 public void addEntry(Entry entry){ //adds a teacher in its correct position
  if(entries.Count == 0) //add teacher when there are no other entries
   entries.Add(entry);
  else
	entries.Add(entry);
 //  sort(teacher, 0); 
 }

 /*public void sort(Entry entry, int index){
 throw new System.ArgumentException("Accessed sort");
  if(index < entries.Count){
   if(string.Compare(entries[index].getPeriod(), entry.getPeriod()) < 0) //teacher comes after this period
    sort(entry, index++);
   else
    entries.Insert(index, entry); //teacher gets added another teacher with the same period and before entries with later periods
  }else
   entries.Add(entry); //teacher is at the end of the day
 }*/
}