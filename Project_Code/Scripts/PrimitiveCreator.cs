using UnityEngine;



public class PrimitiveCreator : MonoBehaviour

{

    private SteamVR_TrackedController _controller;

    private PrimitiveType _currentPrimitiveType = PrimitiveType.Sphere;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }


    private void Update()
    {

        // 1
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // 2
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }

        // 3
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }

    }
    private void OnEnable()

    {

        _controller = GetComponent<SteamVR_TrackedController>();

        _controller.TriggerClicked += HandleTriggerClicked;

        _controller.PadClicked += HandlePadClicked;

        // 1
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // 2
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }

        // 3
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }

    }



    private void OnDisable()

    {

        _controller.TriggerClicked -= HandleTriggerClicked;

        _controller.PadClicked -= HandlePadClicked;

    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    #region Primitive Spawning

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)

    {

        SpawnCurrentPrimitiveAtController();

    }



    private void SpawnCurrentPrimitiveAtController()

    {

        var spawnedPrimitive = GameObject.CreatePrimitive(_currentPrimitiveType);

        spawnedPrimitive.transform.position = transform.position;

        spawnedPrimitive.transform.rotation = transform.rotation;



        spawnedPrimitive.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        if (_currentPrimitiveType == PrimitiveType.Plane)

            spawnedPrimitive.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

    }

    #endregion

    


    #region Primitive Selection

    private void HandlePadClicked(object sender, ClickedEventArgs e)

    {

        if (e.padY < 0)

            SelectPreviousPrimitive();

        else

            SelectNextPrimitive();

    }



    private void SelectNextPrimitive()

    {

        _currentPrimitiveType++;

        if (_currentPrimitiveType > PrimitiveType.Quad)

            _currentPrimitiveType = PrimitiveType.Sphere;

    }



    private void SelectPreviousPrimitive()

    {

        _currentPrimitiveType--;

        if (_currentPrimitiveType < PrimitiveType.Sphere)

            _currentPrimitiveType = PrimitiveType.Quad;

    }

    #endregion

}
