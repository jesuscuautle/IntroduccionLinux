# Comandos Git:
- **Clonar**
Desde la línea de comandos acceder al directorio donde se desea clonar el repositorio, ejemplo:  
**cd** _Directorio/Destino_  
Y clonar el repositorio como sigue:  
**git clone** _jesuscuautle/IntroduccionLinux_  
  
  
- **Git Large File Storage**  
Para resolver problemas de tamaño máximo de archivos que permite GittHub, se usará el plugin LFS de Git, realizar estos pasos ANTES de hacer cualquier cambio al repositorio recien clonado:  
**git lfs install**  
**git lfs track** _"*.asset"_  
**git lfs track** _"*.fbx"_  
**git lfs track** _"*.mp4"_  
Con esto, TODOS los archivos con las extensiones asignadas serán tomados como _Archivos Muy Grandes_, y no generarán ningún problema al momento de subirlos al repositorio en GitHub, una vez realizados estos pasos, la forma ded subir archivos será la siguiente.  
  
  
- **Actualizar repositorio**  
Para los colaboradores, aceeder al direcorio donde se tiene el repositorio clonado y seguir los siguientes comandos:  
*git add* _Archivo o Directorio_ (con el modificador asterísco "*" en el lugar de Archivo o Directorio se agregan TODOS los archivos que hayan sufrido cambios)  
**git commit -m** _"Breve mensaje de la actualización"_  
**git branch -M main**  
**git pull**  
**git push -u origin main**  

# Taller De Introducción a Linux
**Descripción**  
Videojuego para la UEA taller de introduccion a linux  

**Cambios**
- Se agregaron todos los libros que contienen la información del primer tema
- Se agregó una interacción de instrucciones
- Se agregó una interacción para avanzar de nivel
- Se agregó personaje para Quiz (queda pendiente la funcionalidad)
- Se agregó escena de inicio de juego
- Se agregó escena de nivel dos