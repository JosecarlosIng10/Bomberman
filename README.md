# Bomberman
El proyecto  consiste en realizar un juego a partir del análisis de un archivo de entrada que contendrá las instrucciones necesarias para generar el campo, los tesoros, los enemigos y los atributos del personaje principal. Se deberá realizar un análisis léxico al archivo de entrada, para verificar que el archivo no contenga caracteres que no pertenecen al lenguaje. Después de esto se debe realizar un análisis sintáctico, esto para verificar que las instrucciones se encuentren de manera correcta.
El lenguaje se divide en diferentes secciones, permitiendo que esté sea de fácil edición
para cualquier usuario, el lenguaje será de tipo XML (etiquetas). Las secciones que
podemos encontrar son:
• Variables: En esta sección es posible definir variables. Existen 2 tipos de
accesibilidad de las variables: globales y locales. Existen 4 tipos de variables:
cadenas, booleanas y enteros.
• Jugador: En esta sección es posible definir la forma física del jugador y los
atributos de esté, como por ejemplo: vidas, poderes, etc.
• Campo: En esta sección es posible definir la forma que tendrá el campo, tamaño,
obstáculos, bonos, etc.
• Acciones: En esta sección se podrán definir métodos que contendrán una serie
de condición a evaluar cuando el personaje alcance a obtener los bonos del
campo.
• Enemigos: En esta sección se podrá definir los atributos que definirán la forma
física de los enemigos, sus posiciones iniciales y una serie de movimientos que
estos realizarán a través del campo.
