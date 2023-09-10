made a simple db file 
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
// this creates an instance of your main form
Form1 mainForm = new Form1();

// this code basically is what fixed my error when I couldnt figure out why my Form1 wasnt loading anything 
Application.Run(mainForm);
it runs the applications main form, obviously... 

Added a function that will automatically add information for you to the db 
Name 
Age
Added an edit
Edit doesnt work very well and adds its own value like "John" "age 30" very bizzare 
and a delete option 
all the functions work on ID's if you want to select something for now you're gonna have to manually change it in the code till I add UI for that
which is simple to do I already created the integer now all I have to do is refer it 
with a button to reset and start again and a big download button 

## an hour later I figured it out by restructuring the Edit button rather than the shitty yes/no prompt I had previously##
