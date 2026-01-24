# Lista de Tareas (TODO List) - Requisitos

## Asignación de la Masterclass Definitiva de C#

### Resumen General

| Concepto                  | Descripción                                                                                                                                                                                                                                                       |
| ------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Aplicación de Consola** | Esta aplicación es un gestor simple de tareas (TODOs). Cada TODO es simplemente una descripción de algo por hacer (por ejemplo, "Pedir un pastel para la fiesta de cumpleaños"). Cada descripción debe ser única. Los TODOs se pueden agregar, eliminar o listar. |

### Flujo principal de la aplicación

Cuando la aplicación inicia, debe imprimir:  
Hello!  
What do you want to do?  
[S]ee all TODOs  
[A]dd a TODO  
[R]emove a TODO  
[E]xit

El usuario debe seleccionar una de las opciones dadas: S, A, R, E. La opción seleccionada puede ser tanto mayúscula como minúscula, por lo que no importa si el usuario escribe "S" o "s"; ambas deben ir al caso "ver todos los todos".
El usuario puede seguir seleccionando diferentes opciones hasta que seleccione la opción "[E]xit" (Salir), lo cual cerrará la aplicación.

### Selección de una opción por parte del usuario

| Escenario                  | Acción del usuario                                                                               | Resultado                                                                                                                                                                      |
| -------------------------- | ------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Día Soleado (Ideal)        | El usuario selecciona cualquiera de las opciones S,s,A,a,R,r,E,e                                 | La opción correcta es manejada. Al finalizar, se vuelven a imprimir las opciones (a menos que se haya elegido Salir).                                                          |
| Entrada incorrecta o vacía | El usuario no selecciona ninguna opción (elección vacía), o la opción seleccionada no es válida. | Se imprime en consola "Incorrect input" (Entrada incorrecta). Luego, se vuelven a imprimir las opciones. Esto se repite hasta que el usuario proporcione una entrada correcta. |

**Opción "S" - Ver todos los TODOs (See all TODOs)**  
Se debe imprimir en la consola una lista de todos los TODOs, todos prefijados con un índice (comenzando con 1). Por ejemplo, podría verse así:

1. Order a cake for the birthday party.
2. Buy train tickets for the weekend.
3. Take Lucky to the vet.  
   Después de imprimir la lista de TODOs, la aplicación debe imprimir nuevamente "¿Qué quieres hacer?" con todas las opciones disponibles.

**Opción "A" - Agregar un TODO (Add a TODO)**
Después de seleccionar esta opción, la aplicación debe imprimir:  
Enter the TODO description:

Luego, el usuario debe ingresar una descripción única y no vacía para el TODO.  
Una vez hecho esto, la aplicación imprime:

TODO successfully added: [DESCRIPCIÓN]  
Donde [DESCRIPCIÓN] debe ser la descripción que el usuario proporcionó.

El TODO debe agregarse a la colección de TODOs (se puede ver seleccionando la opción "S"). Después de agregar un TODO, la aplicación debe imprimir nuevamente las opciones del menú.

| Escenario            | Acción del usuario                                      | Resultado                                                                                                                                                             |
| -------------------- | ------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Día Soleado          | El usuario introduce una descripción única y no vacía.  | Se imprime **"TODO successfully added: [DESCRIPCIÓN]"**. El TODO se agrega a la colección. Se vuelven a imprimir las opciones.                                        |
| Descripción vacía    | La descripción proporcionada por el usuario está vacía. | Se imprime **"The description cannot be empty."** (La descripción no puede estar vacía). No se agrega ningún TODO. Se vuelve a imprimir "Enter the TODO description". |
| Descripción no única | Ya existe un TODO con la misma descripción.             | Se imprime **"The description must be unique."** (La descripción debe ser única). No se agrega ningún TODO. Se vuelve a imprimir "Enter the TODO description".        |

**Opción "R" - Remover un TODO (Remove a TODO)**  
Después de seleccionar esta opción, la aplicación debe preguntar:  
Select the index of the TODO you want to remove:

Luego, se debe imprimir la lista de todos los TODOs, de manera similar a la opción "S". Si no hay TODOs aún, el programa debe imprimir:  
No TODOs have been added yet.  
El usuario debe seleccionar un índice correcto de la lista dada (ten en cuenta que esta lista está indexada desde 1, por lo que si el usuario selecciona "1", se debe eliminar el primer TODO de la lista).  
Una vez seleccionado el índice correcto, el TODO debe ser eliminado, lo que significa que ya no se mostrará cuando se seleccione la opción "S". Luego, se imprime el siguiente mensaje:  
TODO removed: [DESCRIPCIÓN]
...donde [DESCRIPCIÓN] es la descripción del TODO que acaba de ser eliminado. Luego la aplicación debe imprimir nuevamente las opciones del menú.

| Escenario    | Acción del usuario                                  | Resultado                                                                                                                                           |
| ------------ | --------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| Día Soleado  | El usuario introduce un índice correcto de un TODO. | Se imprime **"TODO removed: [DESCRIPCIÓN]".** El TODO se elimina de la colección. Se vuelven a imprimir las opciones.                               |
| Índice vacío | La entrada del usuario está vacía.                  | Se imprime **"Selected index cannot be empty."** (El índice seleccionado no puede estar vacío). No se elimina nada. Se vuelve a pedir el índice. 15 |

**Opción "E" - Salir (Exit)**  

|Descripción|
|-----------|
|Esta opción simplemente cierra la aplicación |
