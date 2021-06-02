using UnityEngine;
using Cinemachine;

public class TestAnsiedadBeck : MonoBehaviour
{
        private Animator personajeAnimator;   //Animator del personaje
        private AudioSource _audioSource;     //Fuente de sonido del personaje
        private int velocidadGiro = 45;       //Velocidad del Item al rotar sobre y
        private float error = 1;              //Error posible en la posición del personaje
        private float tiempo_retrazo = 1f;    //Tiempo de retardo para aparecer UI
        private float tiempo_salto = 0.5f;    //Tiempo de retardo para iniciar sonido de salto
        private bool disponible;              //Variable de control para la cantidad de clicks
        
        public CinemachineVirtualCamera vcEncuesta;  //Camara virtual para la encuesta
        public GameObject personaje;                 //Personaje que interactúa
        public ParticleSystem particulas;            //Particulas que aparecen al tomar un aguacate
        public GameObject UI;                        //Interfaz gráfica
        public AudioClip jump;                       //Clip de sonido del salto
        public int posElement = -1;                  //Posición actual del Item
        public float xObjetivo;                      //Valor en X donde debe terminar el personaje después de un movimiento
        public float yObjetivo;                      //Valor en Y donde debe terminar el personaje después de un movimiento
        public float zObjetivo;                      //Valor en Z donde debe terminar el personaje después de un movimiento
        
        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            personaje = GameObject.FindWithTag(Constantes.TAG_PERSONAJE);
            personajeAnimator = personaje.GetComponent<Animator>();
            UI.SetActive(true);
            disponible = false;
            CambiaLugar();
        }
        
        /// <summary>
        /// Control del giro del aguacate
        /// </summary>
        void FixedUpdate()
        {
            transform.Rotate(Vector3.up * (velocidadGiro * Time.deltaTime)); //Controla el giro del aguacate
        }   
        
        /// <summary>
        /// Método para iniciar el tiempo de retardo para el cambio de lugar del aguacate
        /// </summary>
        public void CargaPregunta()
        {
            if (disponible)
            {
                disponible = false;
                Invoke("CambiaLugar", Constantes.RETARDO_CARGA_PREGUNTA);
            }
        }

        /// <summary>
        /// Posición nueva que tomará el Aguacate después de ser pulzado y efecto de aparición 
        /// </summary>
        public void CambiaLugar()
        {
            posElement++;
            if (posElement < Constantes.TOTAL_PREGUNTAS_ANSIEDAD_BECK)
            {
                transform.position = new Vector3(
                    Constantes.TESTANSIEDADBECK_X[posElement], 
                    Constantes.TESTANSIEDADBECK_Y[posElement],
                    Constantes.TESTANSIEDADBECK_Z[posElement]);
                gameObject.GetComponent<Animator>().Play(Constantes.ANIMACION_AGUACATE);
            }
            else
            {
                OcultarAguacate();
            }
        }

        /// <summary>
        /// Método que oculta el Item a la vista y animación de partículas 
        /// </summary>
        private void OcultarAguacate()
        {
            transform.position = new Vector3(50,0,10f);
            particulas.transform.position = new Vector3(xObjetivo,yObjetivo+3.5f,zObjetivo);
            particulas.Play();
        }

        /// <summary>
        /// Método que inicia el sonido de salto
        /// </summary>
        private void ReproduceSalto()
        {
            _audioSource.PlayOneShot(jump);
        }

        /// <summary>
        /// Cambia la posición del personaje y oculta el Item x tiempo después
        /// </summary>
        /// <param name="time">Tiempo de retraso para ocultar Item</param>
        private void CambiaPosicion(float time)
        {
            personaje.transform.position = new Vector3(
                xObjetivo,
                yObjetivo,
                zObjetivo
            );
            Invoke("OcultarAguacate",time);
        }
        
        /// <summary>
        /// Al ser pulzado el Item generará un movimiento sobre el Personaje hacia la dirección del item
        /// </summary>
        private void OnMouseDown()
        {
            if(!disponible)
            {
                xObjetivo = Constantes.TESTANSIEDADBECK_X[posElement];
                yObjetivo = Constantes.TESTANSIEDADBECK_Y[posElement];
                zObjetivo = Constantes.TESTANSIEDADBECK_Z[posElement];

                if (personaje.transform.position.y + error < yObjetivo)
                {
                    SaltoArriba();
                }else if (personaje.transform.position.y - error > yObjetivo)
                {
                    SaltoAbajo();
                }
                else
                {
                    SaltoMismoNivel();
                }
            
                Invoke("ReproduceSalto",tiempo_salto);
                vcEncuesta.gameObject.SetActive(true);
                disponible = true;
                UI.GetComponent<Animator>().Play("Abrir");
            }
        }

        /// <summary>
        /// Asigna la animación adecuada para poder bajar y cambia la posición del personaje
        /// </summary>
        private void SaltoAbajo()
        {
            if (personaje.transform.position.x + error < xObjetivo) //Frente x+
            {
                personajeAnimator.Play(Constantes.SALTO_DELANTE_BAJO);
                tiempo_salto = 0.5f;
                CambiaPosicion(tiempo_retrazo);
            }else if (personaje.transform.position.x - error > xObjetivo) //Atrás x-
            {
                tiempo_salto = 0.5f;
                CambiaPosicion(tiempo_retrazo);
            }else if (personaje.transform.position.z + error < zObjetivo) //Izquierda z+
            {
                personajeAnimator.Play(Constantes.SALTO_IZQUIERDA_BAJO);
                tiempo_salto = 0.8f;
                CambiaPosicion(tiempo_retrazo);
            }
            else //Derecha z-
            {
                personajeAnimator.Play(Constantes.SALTO_DERECHA_BAJO);
                tiempo_salto = 1.4f;
                CambiaPosicion(1.8f);
            }
        }

        /// <summary>
        /// Asigna la animación adecuada para poder subir y cambia la posición del personaje
        /// </summary>
        private void SaltoArriba()
        {
            if (personaje.transform.position.z + error < zObjetivo) //Izquierda z+
            {   
                personajeAnimator.Play(Constantes.SALTO_IZQUIERDA_ARRIBA);
                tiempo_salto = 1.8f;
                CambiaPosicion(2.05f);
            }else if (personaje.transform.position.z - error > zObjetivo) //Derecha z-
            {
                personajeAnimator.Play(Constantes.SALTO_DERECHA_ARRIBA);
                tiempo_salto = 1.5f;
                CambiaPosicion(2.05f);
            }
            else //Atrás x-
            {
                personajeAnimator.Play(Constantes.SALTO_ATRAS_ARRIBA);
                tiempo_salto = 1.5f;
                CambiaPosicion(2.05f);
            }
        }
        
        /// <summary>
        /// Asigna la animación adecuada para poder cambiar la posición del personaje
        /// </summary>
        private void SaltoMismoNivel()
        {
            if (personaje.transform.position.x < xObjetivo) //Avanzar hacia adelante x+
            {
                personajeAnimator.Play(Constantes.SALTO_DELANTE_NIVEL);
                tiempo_salto = 0.5f;
                CambiaPosicion(tiempo_retrazo);
            }else if (personaje.transform.position.x > xObjetivo) //Avanzar hacia atrás x-
            {
                personajeAnimator.Play(Constantes.SALTO_ATRAS_NIVEL);
                tiempo_salto = 1.35f;
                CambiaPosicion(1.4f);
            }else if (personaje.transform.position.z < zObjetivo) //Izquierda z+
            {
                personajeAnimator.Play(Constantes.SALTO_IZQUIERDA_NIVEL);
                tiempo_salto = 1.1f;
                CambiaPosicion(1.35f);
            }else //derecha z-
            {
                personajeAnimator.Play(Constantes.SALTO_DERECHA_NIVEL);
                tiempo_salto = 0.8f;
                CambiaPosicion(1f);
            }
        }
    }
