using CallOfDuty;
using System;
using System.Text.RegularExpressions;

string file = "Students.txt";
StudentRepository studentRepository = new StudentRepository(file);
string folder = "dutys";
StudentDuty studentDuty = new StudentDuty(studentRepository, folder);
SelectDuty todayDuty = new SelectDuty(studentDuty);

CommandManager commandManager = new CommandManager();
MainMenu mainMenu = new MainMenu(studentRepository);
commandManager.RegisterCommand("Create", new CommandCreateStudent(mainMenu));
commandManager.RegisterCommand("Pick", new CommandPickStudent(mainMenu, todayDuty));
commandManager.RegisterCommand("Update", new CommandUpdateStudent(mainMenu));
commandManager.RegisterCommand("Show", new CommandShowAllStudent(mainMenu, studentRepository));
commandManager.Start();

