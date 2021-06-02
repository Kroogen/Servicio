
public static class Constantes
{
    //Clave Inicial
    public const string CLAVE_BASE = "12345";

    //Movimientos Animación Personaje
    public const string SALTO_DELANTE_BAJO = "SaltoDelanteAbajo";
    public const string SALTO_IZQUIERDA_BAJO = "SaltoIzquierdaBajo";
    public const string SALTO_DERECHA_BAJO = "SaltoDerechaBajo";
    public const string SALTO_DERECHA_NIVEL = "SaltoDerechaNivel";
    public const string SALTO_IZQUIERDA_NIVEL = "SaltoIzquierdaNivel";
    public const string SALTO_DELANTE_NIVEL = "SaltoDelanteNivel";
    public const string SALTO_ATRAS_NIVEL = "SaltoAtrasNivel";
    public const string SALTO_ATRAS_ARRIBA = "SaltoAtrasArriba";
    public const string SALTO_IZQUIERDA_ARRIBA = "SaltoIzquierdaArriba";
    public const string SALTO_DERECHA_ARRIBA = "SaltoDerechaArriba";

    //Nombres Animación
    public const string ANIMACION_AGUACATE = "Aguacate";
    public const string ANIMACION_MENU_BOTONPULSADO = "BotonPulsado";
    public const string ANIMACION_MENU_BOTONCLICK = "Click";
    public const string ANIMACION_MENU_DESAPARECER = "Desaparecer";

    //Nombre Encuestas
    public const string NOMBRE_ENCUESTA_ZARIT = "Escala de sobrecarga del cuidador - Test de Zarit";
    public const string NOMBRE_ENCUESTA_ANSIEDAD_BECK = "Inventario de Ansiedad de Beck";
    public const string NOMBRE_ENCUESTA_DEPRESION_BECK = "Inventario de Depresión de Beck";
    public const string NOMBRE_ENCUESTA_SPENCE = "Escala de Ansiedad Infantil de Spence";

    public const float RETARDO_CARGA_PREGUNTA = 1.2f;
    public const int TAMANIO_ENCUESTA = 120;
    public const int TAMANIO_RESULTADO = 130;

    //Nombre Elementos Prefab Agregados
    public const string PREFAB_RESPUESTA = "Respuesta";
    public const string PREFAB_ENCUESTA = "Encuesta";
    public const string PREFAB_ENCUESTA_NOMBRE = "ResultadoEncuestaPrefab";
    public const string PREFAB_ENCUESTA_ENCUESTA = "EncuestaPrefab";

    //Envío mensajes
    public const string EMAIL_ASUNTO = "Resultados de encuestas - ";

    //Tags
    public const string TAG_PERSONAJE = "Personaje";

    //Inicio coordenadas X, Y y Z de cada posición posible ------------------

    //Test Zarit
    public static float[] TESTZARIT_X =
    {
        2.1f, 4.2f, 4.2f, 6.3f, 6.3f,
        4.2f, 4.2f, 4.2f, 2.1f, 2.1f,
        2.1f, 0f, 2.1f, 2.1f, 4.2f,
        6.3f, 8.4f, 6.3f, 4.2f, 4.2f,
        4.2f, 6.3f
    };

    public static float[] TESTZARIT_Y =
    {
        5.4f, 3.6f, 3.6f, 1.8f, 1.8f,
        3.6f, 3.6f, 3.6f, 5.4f, 5.4f,
        3.6f, 5.4f, 3.6f, 3.6f, 3.6f,
        1.8f, 0f, 1.8f, 3.6f, 1.8f,
        0, 0
    };

    public static float[] TESTZARIT_Z =
    {
        10.5f, 10.5f, 8.4f, 8.4f, 6.3f,
        6.3f, 8.4f, 10.5f, 10.5f, 8.4f,
        6.3f, 6.3f, 6.3f, 4.2f, 4.2f,
        4.2f, 4.2f, 4.2f, 4.2f, 2.1f,
        0, 0
    };

    //Test Ansiedad Beck
    public static float[] TESTANSIEDADBECK_X =
    {
        0, 0, 2.1f, 2.1f, 4.2f,
        4.2f, 4.2f, 4.2f, 6.3f, 8.4f,
        8.4f, 10.5f, 10.5f, 8.4f, 6.3f,
        4.2f, 4.2f, 6.3f, 6.3f, 8.4f,
        8.4f
    };

    public static float[] TESTANSIEDADBECK_Y =
    {
        7.2f, 7.2f, 5.4f, 5.4f, 3.6f,
        5.4f, 7.2f, 5.4f, 3.6f, 1.8f,
        1.8f, 0, 0, 1.8f, 3.6f,
        5.4f, 3.6f, 3.6f, 1.8f, 1.8f,
        0
    };

    public static float[] TESTANSIEDADBECK_Z =
    {
        8.4f, 6.3f, 6.3f, 4.2f, 4.2f,
        6.3f, 8.4f, 10.5f, 10.5f, 10.5f,
        8.4f, 8.4f, 6.3f, 6.3f, 6.3f,
        6.3f, 4.2f, 4.2f, 2.1f, 2.1f,
        0
    };

    //Test Ansiedad Spence
    public static float[] TESTANSIEDADSPENCE_X =
    {
        0f, 2.1f, 4.2f, 4.2f, 6.3f,
        8.4f, 8.4f, 10.5f, 12.6f, 12.6f,
        12.6f, 10.5f, 10.5f, 8.4f, 8.4f,
        6.3f, 4.2f, 2.1f, 2.1f, 0,
        0, 0, 2.1f, 2.1f, 2.1f,
        0, 0, 0, 2.1f, 2.1f,
        2.1f, 4.2f, 4.2f, 6.3f, 8.4f,
        10.5f, 10.5f, 8.4f, 8.4f, 10.5f,
        10.5f, 12.6f, 12.6f, 10.5f, 50.5f
    };

    public static float[] TESTANSIEDADSPENCE_Y =
    {
        12.6f, 12.6f, 10.8f, 9, 9, //0 - 4
        7.2f, 7.2f, 5.4f, 3.6f, 3.6f, //5 - 9
        3.6f, 5.4f, 3.6f, 5.4f, 5.4f, //10 - 14
        7.2f, 9f, 10.8f, 9f, 10.8f, //15 - 19
        9f, 7.2f, 5.4f, 3.6f, 3.6f, //20 - 24
        5.4f, 5.4f, 5.4f, 3.6f, 3.6f, //25 - 29
        5.4f, 3.6f, 5.4f, 5.4f, 5.4f, //30 - 34
        3.6f, 1.8f, 3.6f, 3.6f, 1.8f, //35 - 39
        1.8f, 1.8f, 0, 1.8f, 0 //40 - 44
    };

    public static float[] TESTANSIEDADSPENCEK_Z =
    {
        16.8f, 16.8f, 16.8f, 14.7f, 14.7f,
        14.7f, 16.8f, 16.8f, 16.8f, 14.7f,
        12.6f, 12.6f, 10.5f, 10.5f, 12.6f,
        12.6f, 12.6f, 12.6f, 10.5f, 10.5f,
        8.4f, 6.3f, 6.3f, 4.2f, 2.1f,
        2.1f, 0, 2.1f, 2.1f, 4.2f,
        6.3f, 6.3f, 8.4f, 8.4f, 8.4f,
        8.4f, 6.3f, 6.3f, 4.2f, 4.2f,
        6.3f, 6.3f, 4.2f, 4.2f, 0f
    };

    //Test Depresion Beck
    public static float[] TESTDEPRESIONBECK_X =
    {
        0,0,2.1f,2.1f,2.1f,
        4.2f,4.2f,6.3f,8.4f,8.4f,
        8.4f,6.3f,4.2f,2.1f,2.1f,
        0,0,2.1f,4.2f,6.3f,
        6.3f
    };
    
    public static float[] TESTDEPRESIONBECK_Y =
    {
        9,7.2f,5.4f,7.2f,7.2f,
        5.4f,3.6f,1.8f,0,-1.8f,
        -1.8f,0,1.8f,3.6f,1.8f,
        3.6f,3.6f,1.8f,1.8f,0,
        0
    };
    
    public static float[] TESTDEPRESIONBECK_Z =
    {
        10.5f,8.4f,8.4f,10.5f,12.6f,
        12.6f,10.5f,10.5f,10.5f,8.4f,
        6.3f,6.3f,6.3f,6.3f,4.2f,
        4.2f,2.1f,2.1f,2.1f,2.1f,
        0
    };
    
    //Fin coordenadas X, Y y Z de cada posición posible ------------------


    //Inicio preguntas de cada encuesta posible ------------------
    //Test Zarit
    public static string[] QUESTIONS_ZARIT =
    {
        "¿Piensa que su familiar le pide más ayuda de la que realmente necesita?",
        "¿Piensa que debido al tiempo que dedica a su familiar no tiene suficiente tiempo para usted?",
        "¿Se siente agobiado por intentar compatibilizar el cuidado de su familiar con otras responsabilidades?\n(trabajo,familia)",
        "¿Siente verguenza por la conducta de su familiar?",
        "¿Se siente enfadado cuando está cerca de su familiar?",
        "¿Piensa que el cuidar de su familiar afecta negativamente la relación que usted tiene con otros miembros de su familia?",
        "¿Tiene miedo por el futuro de su familiar?",
        "¿Piensa que su familiar depende de usted?",
        "¿Se siente tenso cuando está cerca de su familiar?",
        "¿Piensa que su salud ha empeorado debido a tener que cuidar de su familiar?",
        "¿Piensa que no tiene tanta intimidad como le gustaría debido a tener que cuidar de su familiar?",
        "¿Piensa que su vida social se ha visto afectada negativamente por tener que cuidar de su familiar?",
        "¿Se siente incómodo por distanciarse de sus amistades debido a tener que cuidar de su familiar?",
        "¿Piensa que su familiar le considera a usted la úinica persona que le puede cuidar?",
        "¿Piensa que no tiene suficientes ingresos económicos para los gastos de cuidar a su familiar, además de sus otros gastos?",
        "¿Piensa que no será capaz de cuidar a su familiar por mucho más tiempo?",
        "¿Se siente que ha perdido el control de su vida desde que comenzó la enfermedad de su familiar?",
        "¿Desearía poder dejar el cuidado de su familiar a otra persona?",
        "¿Se siente indeciso sobre qué hacer con su familiar?",
        "¿Piensa que debería hacer más por su familiar?",
        "¿Piensa que podría cuidar mejor a su familiar?",
        "Globalmente,¿Qué grado de \"carga\" experimenta por el hecho de cuidar a su familiar?"
    };

    //Test Ansiedad Beck
    public const string QUESTIONS_ANSIEDAD_BECK_CABECERA =
        "Indique cuanto le ha afectado en la última semana incluyendo hoy:";

    public static string[] QUESTIONS_ANSIEDAD_BECK =
    {
        "Torpe o entumecido",
        "Acalorado",
        "Con temblor en las piernas",
        "Incapaz de relajarse",
        "Con temor a que ocurra lo peor",
        "Mareado, o que se le va la cabeza",
        "Con latidos del corazón fuertes y acelerados",
        "Inestable",
        "Atemorizado o asustado",
        "Nervioso",
        "Con sensación de bloqueo",
        "Con temblores en las manos",
        "Inquieto, inseguro",
        "Con miedo a perder el control",
        "Con sensación de ahogo",
        "Con temor a morir",
        "Con miedo",
        "Con problemas digestivos",
        "Con desvanecimientos",
        "Con rubor facial",
        "Con sudores, frios o calientes"
    };

    //Ansiedad de Spence
    public static string[] QUESTIONS_ANSIEDAD_SPENCE =
    {
        "Hay cosas que me preocupan",
        "Me da miedo la oscuridad",
        "Cuando tengo un problema noto una sensación extraña en el estómago",
        "Tengo miedo",
        "Tendría miedo si me quedara solo en casa",
        "Me da miedo hacer un examen",
        "Me da miedo usar aseos públicos",
        "Me preocupo cuando estoy lejos de mis padres",
        "Tengo miedo de hacer el ridículo delante de la gente",
        "Me preocupa hacer mal el trabajo de la escuela",

        "Soy popular entre los niños y niñas de mi edad",
        "Me preocupa que algo malo le suceda a alguien de mi familia",
        "De repente siento que no puedo respirar sin motivo",
        "Necesito comprobar varias veces que he hecho bien las cosas (como apagar la luz, o cerrar la puerta con llave)",
        "Me da miedo dormir solo",
        "Estoy nervioso o tengo miedo por las mañanas antes de ir al colegio",
        "Soy bueno en los deportes",
        "Me dan miedo los perros",
        "No puedo dejar de pensar en cosas malas o tontas",
        "Cuando tengo un problema mi corazón late muy fuerte",

        "De repente empiezo a temblar sin motivo",
        "Me preocupa que algo malo pueda pasarme",
        "Me da miedo ir al médico o al dentista",
        "Cuando tengo un problema me siento nervioso",
        "Me dan miedo los lugares altos o los ascensores",
        "Soy una buena persona",
        "Tengo que pensar en cosas especiales (por ejemplo en un número o en una palabra) para evitar que pase algo malo",
        "Me da miedo viajar en coche, autobús o tren",
        "Me preocupa lo que otras personas piensan de mí",
        "Me da miedo estar en lugares donde hay mucha gente (como centros comerciales, cines, autobuses, parques)",

        "Me siento feliz",
        "De repente tengo mucho miedo sin motivo",
        "Me dan miedo los insectos o las arañas",
        "De repente me siento mareado o creo que me voy a desmayar sin motivo",
        "Me da miedo tener que hablar delante de mis compañeros de clase",
        "De repente mi corazón late muy rápido sin motivo",
        "Me preocupa tener miedo de repente sin que haya nada que temer",
        "Me gusta como soy",
        "Me da miedo estar en lugares pequeños y cerrados (como túneles o habitaciones pequeñas)",
        "Tengo que hacer algunas cosas una y otra vez (como lavarme las manos, limpiar, o poner las cosas en un orden determinado)",

        "Me molestan pensamientos tontos o malos, o imágenes en mi mente",
        "Tengo que hacer algunas cosas de una forma determinada para evitar que pasen cosas malas",
        "Me siento orgulloso de mi trabajo en la escuela",
        "Me daría miedo pasar la noche lejos de mi casa"
    };

    //Final preguntas de cada encuesta posible ------------------


    //Inicio Mensajes base Resultados
    public const string MENSAJE_TITULO_ID = "Id: ";
    public const string MENSAJE_TITULO_NOMBRE = "Nombre: ";
    public const string MENSAJE_TITULO_ENCUESTA = "Encuesta: ";
    public const string MENSAJE_TITULO_RESULTADO = "Resultado: ";

    public const string MENSAJE_TITULO_TOTAL = "Total: ";
    //Final Mensajes base Resultados

    //Inicio respuestas de cada encuesta posible ------------------
    //Test Zarit
    public const string ANSWER_1_ZARIT = "Nunca";
    public const string ANSWER_2_ZARIT = "Rara vez";
    public const string ANSWER_3_ZARIT = "Algunas veces";
    public const string ANSWER_4_ZARIT = "Bastantes veces";
    public const string ANSWER_5_ZARIT = "Casi siempre";
    public const int TOTAL_PREGUNTAS_ZARIT = 22;

    //Test Ansiedad Beck
    public const string ANSWER_1_ANSIEDAD_BECK = "En absoluto";
    public const string ANSWER_2_ANSIEDAD_BECK = "Levemente";
    public const string ANSWER_3_ANSIEDAD_BECK = "Moderadamente";
    public const string ANSWER_4_ANSIEDAD_BECK = "Severamente";
    public const int TOTAL_PREGUNTAS_ANSIEDAD_BECK = 21;

    //Test Ansiedad Spence
    public const string ANSWER_1_ANSIEDAD_SPENCE = "Nunca";
    public const string ANSWER_2_ANSIEDAD_SPENCE = "A veces";
    public const string ANSWER_3_ANSIEDAD_SPENCE = "Muchas veces";
    public const string ANSWER_4_ANSIEDAD_SPENCE = "Siempre";
    public const int TOTAL_PREGUNTAS_ANSIEDAD_SPENCE = 45;

    //Test Depresion Beck
    public static string[] ANSWER_DEPRESION_BECK =
    {
        "No me siento triste",
        "Me siento triste",
        "Me siento triste continuamente y no puedo dejar de estarlo",
        "Me siento tan triste o tan desgraciado que no puedo soportarlo",
        
        "No me siento especialmente desanimado respecto al futuro",
        "Me siento desanimado respecto al futuro",
        "Siento que no tengo que esperar nada",
        "Siento que el futuro es desesperanzador y las cosas no mejorarán",
        
        "No me siento fracasado",
        "Creo que he fracasado más que la mayoría de las personas",
        "Cuando miro hacia atrás, sólo veo fracaso tras fracaso",
        "Me siento una persona totalmente fracasada",
        
        "Las cosas me satisfacen tanto como antes",
        "No disfruto de las cosas tanto como antes",
        "Ya no obtengo una satisfacción auténtica de las cosas",
        "Estoy insatisfecho o aburrido de todo",
        
        "No me siento especialmente culpable",
        "Me siento culpable en bastantes ocasiones",
        "Me siento culpable en la mayoría de las ocasiones",
        "Me siento culpable constantemente",
        
        "No creo que esté siendo castigado",
        "Me siento como si fuese a ser castigado",
        "Espero ser castigado",
        "Siento que estoy siendo castigado",
        
        "No estoy decepcionado de mí mismo",
        "Estoy decepcionado de mí mismo",
        "Me da vergüenza de mí mismo",
        "Me detesto",
        
        "No me considero peor que cualquier otro",
        "Me autocritico por mis debilidades o por mis errores",
        "Continuamente me culpo por mis faltas",
        "Me culpo por todo lo malo que sucede",
        
        "No tengo ningún pensamiento de suicidio",
        "A veces pienso en suicidarme, pero no lo cometería",
        "Desearía suicidarme",
        "Me suicidaría si tuviese la oportunidad",
        
        "No lloro más de lo que solía llorar",
        "Ahora lloro más que antes",
        "Lloro continuamente",
        "Antes era capaz de llorar, pero ahora no puedo, incluso aunque quiera",
        
        "No estoy más irritado de lo normal en mí",
        "Me molesto o irrito más fácilmente que antes",
        "Me siento irritado continuamente",
        "No me irrito absolutamente nada por las cosas que antes solían irritarme",
        
        "No he perdido el interés por los demás",
        "Estoy menos interesado en los demás que antes",
        "He perdido la mayor parte de mi interés por los demás",
        "He perdido todo el interés por los demás",
        
        "Tomo decisiones más o menos como siempre he hecho",
        "Evito tomar decisiones más que antes",
        "Tomar decisiones me resulta mucho más difícil que antes",
        "Ya me es imposible tomar decisiones",
        
        "No creo tener peor aspecto que antes",
        "Me temo que ahora parezco más viejo o poco atractivo",
        "Creo que se han producido cambios permanentes en mi aspecto que me hacen parecer poco atractivo",
        "Creo que tengo un aspecto horrible",
        
        "Trabajo igual que antes",
        "Me cuesta un esfuerzo extra comenzar a hacer algo",
        "Tengo que obligarme mucho para hacer algo",
        "No puedo hacer nada en absoluto",
        
        "Duermo tan bien como siempre",
        "No duermo tan bien como antes",
        "Me despierto una o dos horas antes de lo habitual y me resulta difícil volver a dormir",
        "Me despierto varias horas antes de lo habitual y no puedo volverme a dormir",
        
        "No me siento más cansado de lo normal",
        "Me canso más fácilmente que antes",
        "Me canso en cuanto hago cualquier cosa",
        "Estoy demasiado cansado para hacer nada",
        
        "Mi apetito no ha disminuido",
        "No tengo tan buen apetito como antes",
        "Ahora tengo mucho menos apetito",
        "He perdido completamente el apetito",
        
        "No estoy preocupado por mi salud más de lo normal",
        "Estoy preocupado por problemas físicos como dolores, molestias, malestar de estómago o estreñimiento",
        "Estoy preocupado por mis problemas físicos y me resulta difícil pensar algo más",
        "Estoy tan preocupado por mis problemas físicos que soy incapaz de pensar en cualquier cosa",
        
        "No he observado ningún cambio reciente en mi interés",
        "Estoy menos interesado por el sexo que antes",
        "Estoy mucho menos interesado por el sexo",
        "He perdido totalmente mi interés por el sexo",
        
        "Últimamente he perdido poco peso o no he perdido nada",
        "He perdido más de 2 kilos y medio",
        "He perdido más de 4 kilos",
        "He perdido más de 7 kilos"
    };
    public const int TOTAL_PREGUNTAS_DEPRESION_BECK = 21;


    
    //Final respuestas de cada encuesta posible ------------------
    
    //Inicio Resultado de cada encuesta posible
    //Test Zarit
    public const string RESULTADO_ZARIT_NOSOBRECARGA = " - No sobrecarga";
    public const string RESULTADO_ZARIT_SOBRECARGALEVE = " - Sobrecarga Leve";
    public const string RESULTADO_ZARIT_SOBRECARGAINTENSA = " - Sobrecarga Intensa";
    public const string RESULTADO_ZARIT_NUNCA = "\nNunca: ";
    public const string RESULTADO_ZARIT_RARAVEZ = " - Rara Vez: ";
    public const string RESULTADO_ZARIT_ALGUNAVEZ = " - Algunas Veces: ";
    public const string RESULTADO_ZARIT_BASTANTE = " - Bastantes Veces: ";
    public const string RESULTADO_ZARIT_CASISIEMPRE = " - Casi Siempre: ";
    
    //Test Ansiedad Spence
    public const string RESULTADO_SPENCE_NUNCA = "\nNunca: ";
    public const string RESULTADO_SPENCE_AVECES = "  -  A veces: ";
    public const string RESULTADO_SPENCE_MUCHASVECES = "  -  Muchas Veces: ";
    public const string RESULTADO_SPENCE_SIEMPRE = "  -  Siempre: ";
    public const string RESULTADO_SPENCE_ULTIMA = "Última Pregunta: ";
    
    //Test Depresión Beck
    public const string RESULTADO_DEPRESION_BECK_1 = " - Estos altibajos son considerados normales.";
    public const string RESULTADO_DEPRESION_BECK_2 = " - Leve perturbación del estado de ánimo.";
    public const string RESULTADO_DEPRESION_BECK_3 = " - Estados de depresión intermitentes.";
    public const string RESULTADO_DEPRESION_BECK_4 = " - Depresión moderada.";
    public const string RESULTADO_DEPRESION_BECK_5 = " - Depresión grave.";
    public const string RESULTADO_DEPRESION_BECK_6 = " - Depresión extrema.";
    public const string RESULTADO_DEPRESION_BECK_PUNTUACION = "Puntuación: ";
    
    //Test Ansiedad Beck
    public const string RESULTADO_ANSIEDAD_BECK_ENABSOLUTO = "En Absoluto: ";
    public const string RESULTADO_ANSIEDAD_BECK_LEVEMENTE = "  -  Levemente: ";
    public const string RESULTADO_ANSIEDAD_BECK_MODERADAMENTE = "  -  Moderadamente: ";
    public const string RESULTADO_ANSIEDAD_BECK_SEVERAMENTE = "  -  Severamente: ";
    
    //Final Resultado de cada encuesta posible
    
    //Inicio Mensajes Posibles Configuración
    public const string ERROR_EMAIL = "Verificar el e-mail dado";
    public const string ERROR_PASS = "La contraseña no es válida";
    public const string CONFIRMACION_EMAIL = "El correo se actualizó correctamente";
    public const string CONFIRMACION_PASS = "La contraseña se actualizó correctamente";
    //Final Mensajes Posibles Configuración
    
    //Inicio numeración escenas
    public const int SCENE_MENUPRINCIPAL = 0;
    public const int SCENE_ANSIEDADBECK = 1;
    public const int SCENE_DEPRESIONBECK = 2;
    public const int SCENE_ZARIT = 3;
    public const int SCENE_SPENCE = 4;
    public const int SCENE_ENCUESTAS = 5;
    public const int SCENE_OPCIONES = 6;
    //Final numeración escenas
    
    //Inicio información de Guardado
    public const string SAVE_PLAYER = "/player";
    public const string SAVE_EXTENSION = ".bin";
    public const string SAVE_CONTROL = "/control.bin";
    //Final información de Guardado
}
