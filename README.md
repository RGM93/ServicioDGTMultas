# ServicioDGTMultas
Gestor de Multas con implementación de C#, XAML (WPF) y Net Remoting.

Incluye implementaciones y opciones de:

- "Identificación" (donde se comprobará la autentificación del agente para proceder a gestionar una multa)
   - "Poner Multa" (donde se realizará una multa de un conductor cuyo vehículo ya esté dado de alta previamente, restando los puntos correspondientes).
  - "Quitar Multa" (donde se eliminará una multa de un conductor cuyo vehículo ya esté dado de alta previamente, recuperando los puntos correspondientes).
  - "Dar de Alta" (donde se dará de alta a un conductor con su vehículo si previamente no ha sido dado de alta, asignándose los puntos de carnet iniciales).
  - "Dar de Baja" (donde se dará de baja a un conductor con su vehículo si previamente ha sido dado de alta y no tiene ninguna multa anterior).
  
- "Consultar Puntos" (donde se comprobarán los puntos actuales de un conductor y vehículo).

- "Comprobar Multas" (donde se mostrará una lista de todas las multas actuales de un conductor y vehículo, mostrando la matrícula, la fecha y los puntos quitados).
