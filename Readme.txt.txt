Comentarios generales sobre el proyecto:
	- El proyecto está desarrollado en .NET Core 6
	- La API, según lo solicitado tiene 2(dos) endpoints: uno para obtener el contracto ganador, y otro para obtener la minima firma necesaria para ganar el juicio.
	- Se utiliza la inyección de dependencias y el manejo de la lógica de negocio en la capa de "services" para abstraer la lógica y no generar dependencias innecesarias.
	- Los endpoints correspondientes se han testeado a traves de swagger
	- Se han realizado pruebas unitarias ejecutando el comando "dotnet test" a través de la consola.