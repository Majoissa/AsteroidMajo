# Asteroid

## Configuracion la UI: 
-Menú para empezar nueva partida: tiene el best score, un boton de start game y un boton de reset best score para volverlo a 0
-Durante el juego se ve el current score y el best score, así como el número de vidas (3 vidas). Las vidas son 3 corazones
-Si se supera el bestScore inmediatamente se actualiza en la pantalla
-Una vez que pierde las 3 vidas, el player muere y le aparece un panel de gameOver con la opcion de volver a jugar (restart game) o volver al menu
-La estetica de la UI esta hecha con fonts de google fonts y con los mismos elementos de juego usados a lo largo de la escena de juego ('Game')

## Gestión de best score con datos persistentes
-Hecho con PlayerPrefs

## Sonidos y partículas:
-Sonidos cuando se lanzan las balas
-sonido cuando la bala impacta con el asteroid y lo destruye
-sonido a lo largo de todo el juego (de fondo)
-sistema de particulas cuando el asteroid es impactado por la bala

## Implementación de los asteroides.
-Hay 4 tamaños, si se destruye el mayor tamaño ésta se transforma en dos asteroides promedio. 
-Si se destruye el tamaño medio éste se transforma en 2 asteroides pequeños.
-Se suma puntos cuando se destruye cualquiera de los tamaños--> cuando se destruye el mas grande es menos punto porque es el mas facil de disparar. A medida que disminuye el tamaño de los asteroides, mas puntaje tiene su destruccion
-Los asteroids van apareciendo de manera random en la pantalla

## Teletransport del player: 
-si la nave del player atraviesa alguno de los márgenes, aparece en el lado opuesto.

## Build por web colgado en netlify
-url: https://6563b4fc09319d364340ab63--fluffy-torrone-74bb33.netlify.app/
