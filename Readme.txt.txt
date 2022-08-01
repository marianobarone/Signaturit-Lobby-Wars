Comentarios generales sobre el proyecto:
	- El proyecto est� desarrollado en .NET Core 6
	- La API, seg�n lo solicitado tiene 2(dos) endpoints: uno para obtener el contracto ganador, y otro para obtener la minima firma necesaria para ganar el juicio.
	- Se utiliza la inyecci�n de dependencias y el manejo de la l�gica de negocio en la capa de "services" para abstraer la l�gica y no generar dependencias innecesarias.
	- Los endpoints correspondientes se han testeado a traves de swagger
	- Se han realizado pruebas unitarias ejecutando el comando "dotnet test" a trav�s de la consola.