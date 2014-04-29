class Entry{
 string name, period, room, cCode, cTitle; //cCode & cTitle are course code and title

 public Entry(string name, string period, string room, string cCode, string cTitle){
  this.name = name;
  this.period = period;
  this.room = room;
  this.cCode = cCode;
  this.cTitle = cTitle;
 }
 
 public Entry(){
	name = "";
	period = "";
	room = "";
	cCode = "";
	cTitle = "";
 }

 public string getName(){
  return name;
 }
 public void setName(string name){
  this.name = name;
 }

 public string getPeriod(){
  return period;
 }
 public void setPeriod(string period){
  this.period = period;
 }

 public string getRoom(){
  return room;
 }
 public void setRoom(string room){
  this.room = room;
 }

 public string getcCode(){
  return cCode;
 }
 public void setCCode(string cCode){
  this.cCode = cCode;
 }

 public string getCTitle(){
  return cTitle;
 }
 public void setCTitle(string cTitle){
  this.cTitle = cTitle;
 }

 public override string ToString(){
  return name + "," + period + "," + room + "," + cCode + "," + cTitle;
 }
}