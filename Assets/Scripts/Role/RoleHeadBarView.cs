using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleHeadBarView : MonoBehaviour
{
    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private Text lblNickName;

    /// <summary>
    /// 血条
    /// </summary>
    [SerializeField]
    private Slider sliderHP;

    /// <summary>
    /// 对齐的目标点
    /// </summary>
    private Transform m_Target;

    private RectTransform m_Trans;

    void Start()
    {
       // m_Trans = UISceneCtrl.Instance.CurrentUIScene.CurrCanvas.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (m_Trans == null || m_Target == null) return;

        //得到屏幕坐标
        Vector2 screenPos = Camera.main.WorldToScreenPoint(m_Target.position);

        //接收的UI世界坐标
        Vector3 pos;

        //if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_Trans, screenPos, UI_Camera.Instance.Camera, out pos))
        //{
        //    transform.position = pos;
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="nickName"></param>
    /// <param name="isShowHPBar">是否显示血条</param>
    /// <param name="sliderValue">血条的值</param>
    public void Init(Transform target, string nickName, bool isShowHPBar = false, float sliderValue = 1f)
    {
        m_Target = target;
        lblNickName.text = nickName;

        sliderHP.gameObject.SetActive(isShowHPBar ? true : false);
        sliderHP.value = sliderValue;
    }

    /// <summary>
    /// 设置血条的值
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetSliderHP(float sliderValue)
    {
        sliderHP.value = sliderValue;
    }

    ///// <summary>
    ///// 上弹伤害文字
    ///// </summary>
    ///// <param name="hurtValue"></param>
    //public void Hurt(int hurtValue, float pbHPValue = 0)
    //{
    //    hudText.Add(string.Format("-{0}", hurtValue), Color.red, 0.1f);
    //    pbHP.value = pbHPValue;
    //}
}