Links utiles

https://stackoverflow.com/questions/13028069/unable-to-load-dll-sqlite-interop-dll

Esta solución cuenta con la referencia System.Data.SQLite solo en la capa DataLayer
y una vez que se compila ya se puede distribuir el ejecutable (todo lo que hay en la carpeta Debug)
en un sistema Windows y debería andar correctamente sin problemas.
