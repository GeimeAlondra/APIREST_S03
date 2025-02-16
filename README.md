**Requisitos para uso**

- Visual Studio 2022 o superior
- .NET 8 o superior
- SQL Server

**Instrucciones**

- Abrimos una terminal y ejecutamos el siguiente comando:
  ```sh
  git clone https://github.com/GeimeAlondra/APIREST_S03.git

- Luego, accedemos al directorio del proyecto:
  ```sh
  cd APIREST_S03

- Abrimos SQL Server Management Studio (SSMS) y creamos una nueva base de datos:
  ```sh
  CREATE DATABASE APIREST

- Abrimos Visual Studio y seleccionamos "Abrir un proyecto o solución". Buscamos y abrimos el archivo .sln del proyecto clonado.

- Editamos el archivo appsettings.json y actualizamos el nombre de la instancia de SQLServer junto con el nombre de la base de datos anteriormente creada.
  Los campos que nos interesan son:
  
  - Data Source=.\\SQLEXPRESS; --> Es el nombre de la instancia de SQLServer
  - Initial Catalog=APIREST --> Es el nombre de la base de datos
    
  Debe quedar una cadena similar a esta:

  ```sh
  "ConnectionStrings": {
  "APIConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=APIREST;Integrated Security=True;Trust Server Certificate=True"
  }

- Abrimos la "Consola del administrador de paquetes" en Visual Studio para aplicar las migraciones necesarias para inicializar la base de datos con la estructura definida en el proyecto 
  mediante el comando:
  ```sh
  update-Database

- Una vez completados los pasos anteriores, puedes ejecutar la API desde Visual Studio presionando F5 o ejecutando el comando:
  ```sh
  dotnet run

**Uso de la API**

**Swagger**

- Al iniciar la API se abrira el navegador en https://localhost:5001/swagger (o el puerto en el que esté corriendo la API).

- Ahí podremos explorar los endpoints disponibles.

- Hacemos clic en un endpoint, presionamos "Try it out" e ingresamos los datos requeridos y presionamos "Execute" para probarlo.

**Postman**

- Abrimos Postman y creamos una nueva solicitud https.

- Configuramos la URL base de la API (https://localhost:5001 o el puerto correspondiente).

- Seleccionamos el método HTTP adecuado (GET, POST, PUT, DELETE).

- Si es necesario, agregamos los datos en la pestaña "Body" en formato JSON.

- Presionamos "Send" para ejecutar la solicitud.

- Revisamos la respuesta y ajustamos según sea necesario.

**Endpoints**

- Obtener todos los productos
  ```sh
  GET /api/producto

- Obtener un producto específico
  ```sh
  GET /api/producto/{id}

- Crear un nuevo producto
  ```sh
  POST /api/producto

  {
    "nombre": "Samsung Galaxy S20",
    "precio":499.99,
    "stock": 10
  }

- Actualizar un producto
  ```sh
  PUT /api/producto/{id}

  {
    "id":1,
    "nombre": "Samsung Galaxy S22 Ultra",
    "precio":999.99,
    "stock": 15
  }

- Eliminar un producto
  ```sh
  DELETE /api/producto/{id}
