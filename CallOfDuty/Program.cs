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
commandManager.RegisterCommand("Create", new Create(mainMenu));
commandManager.RegisterCommand("Pick", new Pick(mainMenu, todayDuty));
commandManager.RegisterCommand("Update", new Update(mainMenu, studentRepository));
commandManager.RegisterCommand("Show", new Show(mainMenu, studentRepository));
commandManager.RegisterCommand("Delete", new Delete(mainMenu, studentRepository));
commandManager.RegisterCommand("Clear", new Reset(mainMenu, studentRepository));
commandManager.Start();

