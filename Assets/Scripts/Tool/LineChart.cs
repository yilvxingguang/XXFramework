using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LineChart : MaskableGraphic,ICanvasRaycastFilter
{
    [SerializeField]//曲线个数
    private int lineCount = 1;

    [SerializeField]//颜色
    private List<Color> lineColors = new List<Color>() { };

    [SerializeField]
    private int xwidth = 20;//数据间隔

    private List<float> pointList = new List<float>();

    private Vector3 pos;//数据点的坐标

    private new RectTransform rectTransform;

    private Text numText;


    //两个数据之间的间隔
    private float xLength;


    //最多显示的数据数量
    private const int RemainCount = 50;


    public Vector3 Pos
    {
        get
        {
            return pos;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
        xLength = transform.parent.parent.GetComponent<RectTransform>().sizeDelta.x;
        numText = transform.Find("NumText").GetComponent<Text>();
    }

    private bool IsReachLength = false;
    /// <summary>
    /// 点的添加
    /// </summary>
    /// <param name="point"></param>
    public void AddPoint(float point)
    {
        pointList.Add(point);
        int count = pointList.Count;

        if (count > lineCount)//如果只有一条曲线，则至少有两个点才可以开始绘制曲线
        {
            Vector2 size = rectTransform.sizeDelta;

            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xwidth * (count)); //当数据量达到我们设定的显示上限  数据个数保持不变  这个时候设置他的大小是不发生变化的 
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xwidth * (count + 1));//所以我们就先设置小一单位 在设置加一单位  保证大小变化 
            //此函数改变RectTransform的大小  可以触发OnPopulateMesh调用
            SetVerticesDirty();
            if (size.x > xLength)//显示区域的大小
            {
                if (count > RemainCount)//当数据个数大于我们规定的显示个数  就需要移除前面的数据 
                {
                    pointList.RemoveAt(0);
                    Vector3 pos = transform.localPosition;
                    transform.localPosition = pos + new Vector3(xwidth, 0, 0);//把显示往前移动一个单位 然后做移动动画
                }
                transform.DOLocalMoveX(transform.localPosition.x - xwidth, 0.3f);
            }
        }
    }


    protected override void OnPopulateMesh(VertexHelper vh)
    {
        int _count = pointList.Count;

        //画线
        if (_count > lineCount)
        {
            vh.Clear();
            for (int i = 0; i < _count - lineCount; i++)
            {
                //让曲线宽度在各种斜率下宽度一致
                float k = (pointList[i + lineCount] - pointList[i]) / (xwidth);

                float _y = Mathf.Sqrt(Mathf.Pow(k, 2) + 4);
                _y = Mathf.Abs(_y);
                UIVertex[] verts = new UIVertex[4];

                verts[0].position = new Vector3(xwidth * (i / lineCount), pointList[i] - _y / 2);

                verts[1].position = new Vector3(xwidth * (i / lineCount), _y / 2 + pointList[i]);

                verts[2].position = new Vector3(xwidth * ((i + lineCount) / lineCount), pointList[i + lineCount] + _y / 2);

                verts[3].position = new Vector3(xwidth * ((i + lineCount) / lineCount), pointList[i + lineCount] - _y / 2);

                for (int j = 0; j < 4; j++)
                {
                    verts[j].color = lineColors[(i % lineCount)];
                    verts[j].uv0 = Vector2.zero;
                }
                vh.AddUIVertexQuad(verts);
            }
        }
        //draw quad  显示数据大小的方块点
        for (int i = 0; i < _count; i++)
        {
            UIVertex[] quadverts = new UIVertex[4];
            quadverts[0].position = new Vector3((i / lineCount) * xwidth - 1.5f, pointList[i] - 1.5f);
            quadverts[0].color = Color.white;
            quadverts[0].uv0 = Vector2.zero;

            quadverts[1].position = new Vector3((i / lineCount) * xwidth - 1.5f, pointList[i] + 1.5f);
            quadverts[1].color = Color.white;
            quadverts[1].uv0 = Vector2.zero;

            quadverts[2].position = new Vector3((i / lineCount) * xwidth + 1.5f, pointList[i] + 1.5f);
            quadverts[2].color = Color.white;
            quadverts[2].uv0 = Vector2.zero;

            quadverts[3].position = new Vector3((i / lineCount) * xwidth + 1.5f, pointList[i] - 1.5f);
            quadverts[3].color = Color.white;
            quadverts[3].uv0 = Vector2.zero;

            vh.AddUIVertexQuad(quadverts);
        }
    }



    //如果鼠标在数据点上 就会返回true
    public bool IsRaycastLocationValid(UnityEngine.Vector2 sp, UnityEngine.Camera eventCamera)
    {
        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, sp, eventCamera, out local);
        Rect rect = GetPixelAdjustedRect();

        local.x += rectTransform.pivot.x * rect.width;
        local.y += rectTransform.pivot.y * rect.height;
        int _count = pointList.Count;
        for (int i = 0; i < _count; i++)
        {
            if (local.x > (i / lineCount) * xwidth - 3f && local.x < ((i / lineCount) * xwidth + 3f) && local.y > (pointList[i] - 3f)
                && local.y < (pointList[i] + 3f))
            {
                pos = new Vector3((i / lineCount) * xwidth, pointList[i], 0);
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        //鼠标是否放在白点处
        if (IsRaycastLocationValid(Input.mousePosition, null))
        {
            numText.gameObject.SetActive(true);
            numText.text = (pos.y).ToString();
            numText.transform.localPosition = pos;
        }
        else
        {
            numText.gameObject.SetActive(false);
        }
    }



}
