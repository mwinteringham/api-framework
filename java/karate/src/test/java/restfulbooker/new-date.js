function() {
  var sm = new java.text.SimpleDateFormat("yyyy-MM-dd");
  var date = new java.util.Date();
  return sm.format(date);
}
