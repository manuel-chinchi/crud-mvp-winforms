# Crud MVP WinForms

Sistema básico con operaciones CRUD hecho en .Net Framework 4.5 y SQL Server.

## ¿De qué trata esta aplicación? 

Este proyecto consiste en una pequeña aplicación de escritorio para sistemas Windows. La 
cual permite el registro y actualización de Artículos y su agrupación por Categorías. Además
tiene una sección de reportes donde se pueden visualizar los datos de manera clara y exportarlos
a otros formatos.

## ¿Cómo ejecutar la aplicación?

Para poder ejecutar el programa se requiere tener instalado los siguientes componentes

* [Runtime de .Net Framework 4.5](https://www.microsoft.com/es-ar/download/details.aspx?id=42642)
* [SQL Server 2018/2019](https://www.microsoft.com/es-ar/download/details.aspx?id=101064)
* Microsoft SQL Server Management Studio (SSMS) *(opcional)*

Una vez instalados seguir los siguientes pasos para probar la aplicación.

1. Descargar la última versión del proyecto compilado [desde aquí](https://github.com/manuel-chinchi/crud-mvp-winforms/releases) y descomprimir
en algún directorio.
2. Abrir el script `db_squema_and_data.min.sql` desde SSMS y ejecutarlo
para crear la base de datos.
3. Abrir el archivo `crud-mvp-winforms.exe.config` y configurar la cadena de
conexión a para que apunte a su base de datos local.
4. Ejecutar el archivo `crud-mvp-winforms.exe` e interactuar, eso es todo.

**ADICIONAL**

*Si quiere probar la aplicación solamente sin tener que crear o configurar una
base de datos SQL Server puede descargar [desde aquí](https://github.com/manuel-chinchi/crud-mvp-winforms/releases/tag/v1.0.1) una versión portable
que usa SQLite.*

## Arquitectura de la aplicación

Esta aplicación cuenta con una estructura tipo Modelo-Vista-Presentador (MVP) 
en la cual los presentadores conectan los modelos a las vistas mediante 
los contratos correspondientes, en los presentadores se maneja toda la lógica
de aplicación. 
Ademá, la aplicación se encuentra separada en cinco capas (proyectos) para su mejor organización.
 
 - **EntityLayer**: La capa que contiene los modelos de datos.
 - **DataLayer**: Es la capa de acceso a datos, contiene los repositorios y la configuración
 de la conexión a la base de datos.
 - **BussinesLayer**: La capa que contiene los servicios de la aplicación. 
 - **PresentationLayer**: Capa de presentación, se encarga de mostrar las vistas
   e interactuar con los modelos. 
 - **TestLayer**: Es una capa adicional que contiene algunas pruebas relacionadas a la capa
 de *BussinesLayer*.

## Entorno de desarollo

* Visual Studio IDE 2019
  * Configuración
    * Cascadia Code ExtraLight (fuente)
  * Extensiones
    * Diseñador de informes RDLC de Microsoft para Visual Studio v15.3.1
    * Git Diff Margin v3.12.1 (by Laurent Kempé)
    * PowerShell Tools for Visual Studio v2024.1.0 (by Ironman Software)
* Sublime Text
* Greenshot (capturas de pantalla)

## Diagrama de clases

<p align="center">
    <img src="resources/ClassDiagram.png">
</p>


## Capturas

<p align="center">
    <img src="resources/screenshots/ArticleListView.png" alt="" width="708">
</p>
<p align="center">
    <img src="resources/screenshots/ArticleCreateView.png" alt="" width="269">
</p>
<p align="center">
    <img src="resources/screenshots/ReportView.png" alt="" width="644">
</p>
Validaciones
<p align="center">
    <img src="resources/screenshots/ErrorMessage-ArticleCreateView.png" width="269">
</p>
<p align="center">
    <img src="resources/screenshots/SuccessMessage-ArticleListView.png" width="708">
</p>

## Licencia
  GPL-3.0


## Referencias útiles

- [System.Configuration reference not found](https://stackoverflow.com/questions/4431034/configurationmanager-not-found)
- [DataGridView using SortableBindingList](https://stackoverflow.com/questions/23661195/datagridview-using-sortablebindinglist)
- [CheckBox in header of DataGridView for select all rows](https://stackoverflow.com/questions/8906575/checkbox-in-the-header-of-a-datagridview-in-any-column)
- [Checkbox in header of DataGridView](https://stackoverflow.com/questions/8906575/checkbox-in-the-header-of-a-datagridview-in-any-column)

- MSTests utils
  - [Documentacion MS](https://learn.microsoft.com/en-us/visualstudio/test/vstest-console-options?view=vs-2022)
  - [Sample Export](https://stackoverflow.com/questions/56958300/how-do-i-save-test-results-from-test-explorer-in-visual-studio-2017)

- Others
  - https://www.youtube.com/watch?v=LULI64meTUs
