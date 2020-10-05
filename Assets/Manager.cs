using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.Assistant.V2;
using IBM.Watson.Assistant.V2.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public string apiK = "uMNbtEfGKcg8vCAEqSkW2M2sfOs6AZz3Z8WmxvtPBUJI";
    public string sURL = "https://api.us-south.assistant.watson.cloud.ibm.com";
    public string VersionDate = "2020-09-24";
    public string assID = "b85bf0f4-d882-40d9-94ba-185b3a3bd2b7";
    public string sesID = "";
    private AssistantService service;

    private bool createSessionTested = false;
    private bool messageTested0 = false;
    private bool messageTested1 = false;
    private bool messageTested2 = false;
    private bool messageTested3 = false;
    private bool messageTested4 = false;
    private bool deleteSessionTested = false;

    //agencia aeroespacial canadiense


    public static Manager Singleton;

    public float EscalaTiempo=1;

    public int hambre=100;
    public Slider SLDhambre;
    public Button BTNalimentar;
    

    public string RespuestaBot;
    public Text textelement;

    public int TasaDeHambre=5;
    public int TiempoTranscurrido;
    public int TiempoHambre;
    public int TiempoRspuesta;
    public int TiempoSonido;

    public Mascot MascotaActual;
    public Mascot[] EstadosMascota;
    /*
        0-estado base
        1-estado especial 1
        ...
    */

    private string peticion;

    public AudioClip FXsonido1;
    public AudioClip FXsonido2;
    public AudioClip FXsonido3;
    public AudioClip FXsonido4;
    public AudioClip FXsonido5;
    public AudioClip FXsonido6;
    public AudioClip FXsonido7;
    public AudioClip FXsonido8;
    public AudioClip FXsonido9;
    public AudioClip FXsonido10;
    public AudioClip FXsonido11;
    public AudioClip FXsonido12;
    public AudioClip FXsonido13;
    public AudioClip FXsonido14;
    public AudioClip FXsonido15;
    public AudioClip FXsonido16;
    public AudioClip FXsonido17;
    public AudioClip FXsonido18;
    public AudioClip FXsonido19;
    public AudioClip FXsonido20;
    public AudioClip FXsonido21;
    public AudioClip FXsonido22;
    public AudioClip FXsonido23;
    public AudioClip FXsonido24;
    public AudioClip FXsonido25;
    public AudioClip FXsonido26;
    public AudioClip FXsonido27;
    public AudioClip FXsonido28;
    public AudioClip FXsonido29;
    public AudioClip FXsonido30;
    public AudioClip FXsonido31;
    public AudioClip FXsonido32;
    public AudioClip FXsonido33;
    public AudioClip FXsonido34;
    public AudioClip FXsonido35;
    public AudioClip FXsonido36;
    public AudioClip FXsonido37;
    public AudioClip FXsonido38;
    public AudioClip FXsonido39;
    public AudioClip FXsonido40;

    public AudioClip FXLadrido1;
    public AudioClip FXLadrido2;
    public AudioClip FXLadrido3;
    public AudioClip FXLadrido4;
    public AudioClip FXHambre;
    public AudioClip FXcomer;

    private AudioSource audioPlayer;


    private void Awake()
    {
        
        if (Singleton == null){Singleton = this;}
        else{ Destroy(this); }
    }

    void SetUp()
    {
        hambre = 100;
        SLDhambre.value = hambre;
    }
    
    //private void AutWatson(){
        
    //}


    // Start is called before the first frame update
    private void Start()
    {
        SetUp();
        
        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());

        audioPlayer = GetComponent<AudioSource>();
        MascotaActual = Instantiate(EstadosMascota[0], Vector3.zero,Quaternion.identity) as Mascot;
        InvokeRepeating("ActualizarCosas", 0, EscalaTiempo);
        BTNalimentar.onClick.AddListener(Alimentar);
    }

    void Alimentar()
    {
        if (hambre == 0)
        {
            audioPlayer.clip = FXcomer;
            audioPlayer.Play();
            hambre = 100;
            try { Runnable.Run(RespuestaUser("datocuriosoespacialWOW")); }
            catch
            {
                Runnable.Run(DeleteSession());
                Runnable.Run(CreateService());
                Runnable.Run(CreateSession());
                Runnable.Run(RespuestaUser("datocuriosoespacialWOW"));
            }
        }
    }

    private void FxSonidos()
    {

        int rand = Random.Range(1, 40);
        if (rand == 1) { audioPlayer.clip = FXsonido1; }
        if (rand == 2) { audioPlayer.clip = FXsonido2; }
        if (rand == 3) { audioPlayer.clip = FXsonido3; }
        if (rand == 4) { audioPlayer.clip = FXsonido4; }
        if (rand == 5) { audioPlayer.clip = FXsonido5; }
        if (rand == 6) { audioPlayer.clip = FXsonido6; }
        if (rand == 7) { audioPlayer.clip = FXsonido7; }
        if (rand == 8) { audioPlayer.clip = FXsonido8; }
        if (rand == 9) { audioPlayer.clip = FXsonido9; }
        if (rand == 10) { audioPlayer.clip = FXsonido10; }
        if (rand == 11) { audioPlayer.clip = FXsonido11; }
        if (rand == 12) { audioPlayer.clip = FXsonido12; }
        if (rand == 13) { audioPlayer.clip = FXsonido13; }
        if (rand == 14) { audioPlayer.clip = FXsonido14; }
        if (rand == 15) { audioPlayer.clip = FXsonido15; }
        if (rand == 16) { audioPlayer.clip = FXsonido16; }
        if (rand == 17) { audioPlayer.clip = FXsonido17; }
        if (rand == 18) { audioPlayer.clip = FXsonido18; }
        if (rand == 19) { audioPlayer.clip = FXsonido19; }
        if (rand == 20) { audioPlayer.clip = FXsonido20; }
        if (rand == 21) { audioPlayer.clip = FXsonido21; }
        if (rand == 22) { audioPlayer.clip = FXsonido22; }
        if (rand == 23) { audioPlayer.clip = FXsonido23; }
        if (rand == 24) { audioPlayer.clip = FXsonido24; }
        if (rand == 25) { audioPlayer.clip = FXsonido25; }
        if (rand == 26) { audioPlayer.clip = FXsonido26; }
        if (rand == 27) { audioPlayer.clip = FXsonido27; }
        if (rand == 28) { audioPlayer.clip = FXsonido28; }
        if (rand == 29) { audioPlayer.clip = FXsonido29; }
        if (rand == 30) { audioPlayer.clip = FXsonido30; }
        if (rand == 31) { audioPlayer.clip = FXsonido31; }
        if (rand == 32) { audioPlayer.clip = FXsonido32; }
        if (rand == 33) { audioPlayer.clip = FXsonido33; }
        if (rand == 34) { audioPlayer.clip = FXsonido34; }
        if (rand == 35) { audioPlayer.clip = FXsonido35; }
        if (rand == 36) { audioPlayer.clip = FXsonido36; }
        if (rand == 37) { audioPlayer.clip = FXsonido37; }
        if (rand == 38) { audioPlayer.clip = FXsonido38; }
        if (rand == 39) { audioPlayer.clip = FXsonido39; }
        if (rand == 40) { audioPlayer.clip = FXsonido40; }

        audioPlayer.Play();

    }

    void ActualizarCosas()
    {
        if (TiempoHambre>TasaDeHambre)
        {
            TiempoHambre = 0;
            if (hambre > 0) { hambre--; }
            SLDhambre.value = hambre;
        }
        if (hambre == 1)
        {
            hambre = 0;
            audioPlayer.clip = FXHambre;
            audioPlayer.Play();
        }

        if (TiempoSonido == 60)
        {
            FxSonidos();
            TiempoSonido = 0;
        }

        if (TiempoRspuesta==200) { ReadStringInput("EstoyAusenteyNoHablo"); }
        TiempoHambre++;
        TiempoSonido++;
        TiempoRspuesta++;
    }

    private IEnumerator CreateService()
    {
        // Solicitud de clave api
        if (string.IsNullOrEmpty(apiK)) {throw new IBMException("Plesae provide IAM ApiKey for the service.");}
        IamAuthenticator authenticator = new IamAuthenticator(apikey: apiK);
        print("clave ok");

        // Verificacion de token
        while (!authenticator.CanAuthenticate()) { yield return null; }
        print("token ok");

        // Crear el servicio
        service = new AssistantService(VersionDate, authenticator);
        print("servicio ok");

        // Establecer URL e servicio
        service.SetServiceUrl(sURL);
        print("url ok");
        service.WithHeader("X-Watson-Learning-Opt-Out", "true");
        Runnable.Run(CreateSession());
    }

    private IEnumerator CreateSession(){
        // Crear session
        Log.Debug("ExampleAssistantV2.RunExample()", "Attempting to CreateSession");
        service.CreateSession(OnCreateSession, assID);
        while (!createSessionTested) { yield return null; }
        print("id sesion ok");
        print(sesID);
    }
    private void OnCreateSession(DetailedResponse<SessionResponse> response, IBMError error)
    {
        Log.Debug("ExampleAssistantV2.OnCreateSession()", "Session: {0}", response.Result.SessionId);
        sesID = response.Result.SessionId;
    }


    private IEnumerator DeleteSession()
    {
        Log.Debug("ExampleAssistantV2.RunExample()", "Attempting to delete session");
        service.DeleteSession(OnDeleteSession, assID, sesID);

        while (!deleteSessionTested){yield return null;}
    }
    private void OnDeleteSession(DetailedResponse<object> response, IBMError error)
    {
        Log.Debug("ExampleAssistantV2.OnDeleteSession()", "Session deleted.");
        deleteSessionTested = true;
    }

    


    private void FxLadridos()
    {
        
        int rand =Random.Range(1,4);
        if (rand == 1) { audioPlayer.clip = FXLadrido1; }
        if (rand == 2) { audioPlayer.clip = FXLadrido2; }
        if (rand == 3) { audioPlayer.clip = FXLadrido3; }
        if (rand == 4) { audioPlayer.clip = FXLadrido4; }
        audioPlayer.Play();

    }

    public void ReadStringInput(string s)
    {
        TiempoRspuesta = 0;
        FxLadridos();
        try { Runnable.Run(RespuestaUser(s)); }
        catch
        {
            Runnable.Run(DeleteSession());
            Runnable.Run(CreateService());
            Runnable.Run(CreateSession());
            Runnable.Run(RespuestaUser(s));
        }
        TiempoRspuesta = 0;
    }

    private IEnumerator RespuestaUser(string s)
    {
        var input1 = new MessageInput()
        {
            Text = s,
            Options = new MessageInputOptions()
            {
                ReturnContext = true
            }
        };
        Log.Debug("ExampleAssistantV2.RunExample()", "Attempting to Message");
        service.Message(OnMessage, assID, sesID, input: input1);

        while (!messageTested0){yield return null;}
    }


    private void OnMessage(DetailedResponse<MessageResponse> response, IBMError error)
    {
        Log.Debug("Peticion", "response: {0}", response.Result.Output.Generic[0].Text);
        messageTested0 = true; 
        RespuestaBot = response.Result.Output.Generic[0].Text.ToString();
        textelement.text = RespuestaBot;
        
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
