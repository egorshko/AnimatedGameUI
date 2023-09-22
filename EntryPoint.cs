using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private UiAnimationConfig _uiConfig;

    private List<IController> _controllers = new();
    private List<IExecute> _executeController = new();
    private List<ICleanUp> _cleanUpControllers = new();

    void Start()
    {
        UiFactory uiFactory = new UiFactory(_uiConfig);
        UiInitialization uiInitialization = new UiInitialization(uiFactory);

        _controllers.Add(new UiController(_uiConfig, uiInitialization));

        foreach (IController controller in _controllers)
        {
            if (controller is IExecute executeController)
            {
                _executeController.Add(executeController);
            }

            if (controller is ICleanUp cleanUpControllers)
            {
                _cleanUpControllers.Add(cleanUpControllers);
            }
        }
    }

    private void Update()
    {
        float deltatime = Time.deltaTime;

        for (int i = 0; i < _executeController.Count; i++)
        {
            _executeController[i].Execute(deltatime);
        }
    }

    private void OnDestroy()
    {
        foreach (ICleanUp controller in _cleanUpControllers)
        {
            controller.CleanUp();
        }
    }
}
