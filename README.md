# ServicioDGTMultas
Gestor de Multas con implementación de C#, XAML (WPF) y Net Remoting.

Incluye implementaciones y opciones de:

- "Identificación" (donde se comprobará la autentificación del agente para proceder a gestionar una multa)
  
- "Consultar Puntos" (donde se comprobarán los puntos actuales de un conductor y vehículo).

- "Comprobar Multas" (donde se mostrará una lista de todas las multas actuales de un conductor y vehículo, mostrando la matrícula, la fecha y los puntos quitados).

Dentro de "Identificación" tendremos las siguientes implementaciones y opciones:

- "Poner Multa" (donde se realizará una multa de un conductor cuyo vehículo ya esté dado de alta previamente, restando los puntos correspondientes).
- "Quitar Multa" (donde se eliminará una multa de un conductor cuyo vehículo ya esté dado de alta previamente, recuperando los puntos correspondientes).
- "Dar de Alta" (donde se dará de alta a un conductor con su vehículo si previamente no ha sido dado de alta, asignándose los puntos de carnet iniciales).
- "Dar de Baja" (donde se dará de baja a un conductor con su vehículo si previamente ha sido dado de alta y no tiene ninguna multa anterior).

* Cambios a realizar para el correcto funcionamiento del proyecto * 

- Paso 1: Una vez descargado el proyecto, compilar todas las soluciones para que se generen los correspondientes .dll necesarios para sus referencias.

- Paso 2: Añadir las referencias necesarias de cada solución. Realizamos click derecho en la solución y elegir la opción de "Agregar" -> "Referencia", le damos a "Examinar", y buscamos la referencia del proyecto que necesitamos en la carpeta de la solución, en la dirección a modo de ejemplo ComunDGTMultas/obj/Debug/ y seleccionamos el archivo ComunDGTMultas.dll. Dicho .dll, como se ha comentado antes, se genera tras haber compilado cada uno de las soluciones.

- Paso 3: Comprobar que todas las referencias estén bien añadidas y no genere ningún tipo de error de compilación, y ejecutar primeramente la solución "ServidorMultas", y una vez ejecutado y que se haya abierto el terminal correspondiente, ejecutar "ClienteMultas" para una ejecución en 'texto plano' o "InterfazGrafica" para una ejecución con 'Diseño de Interfaz de Usuario'.
