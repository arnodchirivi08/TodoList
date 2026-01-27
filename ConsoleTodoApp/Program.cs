using ConsoleTodoApp;
using TodoTdd;

IConsole consolaTodo = new Consola();
var validador = new ValidadorComando();
var listadoTareas =  new ListaDeTareas();


var tareasApp = new TareasApp(consolaTodo, listadoTareas, validador);


tareasApp.Ejecutar();