using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class DrawCircle : MonoBehaviour
{
    public enum Axis { X, Y, Z };

    [SerializeField]
    [Tooltip("The number of lines that will be used to draw the circle. The more lines, the more the circle will be \"flexible\".")]
    [Range(0, 1000)]
    private int segments = 60;

    [SerializeField]
    [Tooltip("The radius of the horizontal axis.")]
    private float horizRadius = 10;

    [SerializeField]
    [Tooltip("The radius of the vertical axis.")]
    private float vertRadius = 10;

    [SerializeField]
    [Tooltip("The offset will be applied in the direction of the axis.")]
    private float offset = 0;

    [SerializeField]
    [Tooltip("The axis about which the circle is drawn.")]
    private Axis axis = Axis.Z;

    [SerializeField]
    [Tooltip("If checked, the circle will be rendered again each time one of the parameters change.")]
    private bool checkValuesChanged = true;

    private int previousSegmentsValue;
    private float previousHorizRadiusValue;
    private float previousVertRadiusValue;
    private float previousOffsetValue;
    private Axis previousAxisValue;

    private LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;

        UpdateValuesChanged();

        CreatePoints();
    }

    void Update()
    {
        if (checkValuesChanged)
        {
            if (previousSegmentsValue != segments ||
                previousHorizRadiusValue != horizRadius ||
                previousVertRadiusValue != vertRadius ||
                previousOffsetValue != offset ||
                previousAxisValue != axis)
            {
                CreatePoints();
            }

            UpdateValuesChanged();
        }
    }

    void UpdateValuesChanged()
    {
        previousSegmentsValue = segments;
        previousHorizRadiusValue = horizRadius;
        previousVertRadiusValue = vertRadius;
        previousOffsetValue = offset;
        previousAxisValue = axis;
    }

    void CreatePoints()
    {

        if (previousSegmentsValue != segments)
        {
            line.SetVertexCount(segments + 1);
        }

        float x;
        float y;
        float z = offset;

        float angle = 0f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * horizRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * vertRadius;

            switch (axis)
            {
                case Axis.X:
                    line.SetPosition(i, new Vector3(z, y, x));
                    break;
                case Axis.Y:
                    line.SetPosition(i, new Vector3(y, z, x));
                    break;
                case Axis.Z:
                    line.SetPosition(i, new Vector3(x, y, z));
                    break;
                default:
                    break;
            }

            angle += (360f / segments);
        }
    }
}
