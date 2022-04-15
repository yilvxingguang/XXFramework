//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//////如果好用，请收藏地址，帮忙分享。
////public class TaskBook
////{
////    /// <summary>
////    /// 花卉上盆
////    /// </summary>
////    public string Name { get; set; }
////    /// <summary>
////    /// 花卉上盆是将苗床中繁殖的幼苗(播种苗、扦插苗)栽植到花盆中的操作过程;上盆前应挑选大小合适,完好无损的花盆,否则会影响花苗的正常生长和花卉的观赏价值。
////    /// </summary>
////    public string ProjectDescription { get; set; }
////    /// <summary>
////    /// 本次任务以盆栽山茶为例,展示花卉上盆的操作过程和注意事项。
////    /// </summary>
////    public string TaskContent { get; set; }
////    /// <summary>
////    /// 1花盆处理-→2加培养土→3开始移苗-→4移后处理
////    /// </summary>
////    public string TaskSteps { get; set; }
////}

////public class StepsDetailItem
////{
////    /// <summary>
////    /// 花铲
////    /// </summary>
////    public string ToolName { get; set; }
////    /// <summary>
////    /// 园艺中常见的铲子
////    /// </summary>
////    public string ToolIntroduce { get; set; }
////    /// <summary>
////    /// 换盆前,应暂停浇水2-3天，可达到自动收边效果,若不收边,可使用花铲沿盆壁插一周，使土与盆壁分开
////    /// </summary>
////    public string TxtStepsDetail { get; set; }
////    /// <summary>
////    /// 换盆时间宜为晴天的上午,宜在早春枝条未萌发前或秋季植株生长即将停止时换盆
////    /// </summary>
////    public string TxtTip { get; set; }
////}

////public class StepsGeneralizationItem
////{
////    /// <summary>
////    /// 第一步：花盆处理
////    /// </summary>
////    public string TxtStepsGeneralization { get; set; }
////    /// <summary>
////    /// 清理并消毒栽植盆，盆底洞眼用双瓦片斜搭为“入”字形，“盖而不堵，挡而不死”
////    /// </summary>
////    public string StepsGeneralizationDescribe { get; set; }
////    /// <summary>
////    /// 
////    /// </summary>
////    public List<StepsDetailItem> StepsDetail { get; set; }
////}

////public class MainSceneTxtData
////{
////    /// <summary>
////    /// 
////    /// </summary>
////    public TaskBook TaskBook { get; set; }
////    /// <summary>
////    /// 
////    /// </summary>
////    public List<StepsGeneralizationItem> StepsGeneralization { get; set; }
////    /// <summary>
////    /// 木本花卉的大苗-般在12月初到3月底当花木休眠或刚萌发时上盆,否则会影响正常生长发育,这样就需要较长时间才能复壮。集中扦插繁殖的,待生根放叶后,应该及时分苗上盆。播种的新苗，宜在成株时上盆。在多数宿根花卉,应在幼芽刚开始萌动时上盆。
////    /// </summary>
////    public string DailyMaintenance { get; set; }
////}

////public class Root
////{
////    /// <summary>
////    /// 
////    /// </summary>
////    public MainSceneTxtData MainSceneTxtData { get; set; }
////}

////如果好用，请收藏地址，帮忙分享。
//public class TaskBook
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public string EnglishName { get; set; }
//    /// <summary>
//    /// 花卉上盆
//    /// </summary>
//    public string ChineseName { get; set; }
//    /// <summary>
//    /// 花卉上盆是将苗床中繁殖的幼苗(播种苗、扦插苗)栽植到花盆中的操作过程;上盆前应挑选大小合适,完好无损的花盆,否则会影响花苗的正常生长和花卉的观赏价值。
//    /// </summary>
//    public string ProjectDescription { get; set; }
//    /// <summary>
//    /// 本次任务以盆栽山茶为例,展示花卉上盆的操作过程和注意事项。
//    /// </summary>
//    public string TaskContent { get; set; }
//    /// <summary>
//    /// 1花盆处理-→2加培养土→3开始移苗-→4移后处理
//    /// </summary>
//    public string TaskSteps { get; set; }
//}

//public class StepsDetailItem
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ToolEnglishName { get; set; }
//    /// <summary>
//    /// 花铲
//    /// </summary>
//    public string ToolChineseName { get; set; }
//    /// <summary>
//    /// 园艺中常见的铲子
//    /// </summary>
//    public string ToolIntroduce { get; set; }
//    /// <summary>
//    /// 换盆前,应暂停浇水2-3天，可达到自动收边效果,若不收边,可使用花铲沿盆壁插一周，使土与盆壁分开
//    /// </summary>
//    public string TxtStepsDetail { get; set; }
//    /// <summary>
//    /// 换盆时间宜为晴天的上午,宜在早春枝条未萌发前或秋季植株生长即将停止时换盆
//    /// </summary>
//    public string TxtTip { get; set; }
//}

//public class StepsGeneralizationItem
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public string TxtStepsGeneralizationEnglish { get; set; }
//    /// <summary>
//    /// 第一步：花盆处理
//    /// </summary>
//    public string TxtStepsGeneralizationChinese { get; set; }
//    /// <summary>
//    /// 清理并消毒栽植盆，盆底洞眼用双瓦片斜搭为“入”字形，“盖而不堵，挡而不死”
//    /// </summary>
//    public string StepsGeneralizationDescribe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public List<StepsDetailItem> StepsDetail { get; set; }
//}

//public class MainSceneTxtData
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public TaskBook TaskBook { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public List<StepsGeneralizationItem> StepsGeneralization { get; set; }
//    /// <summary>
//    /// 木本花卉的大苗-般在12月初到3月底当花木休眠或刚萌发时上盆,否则会影响正常生长发育,这样就需要较长时间才能复壮。集中扦插繁殖的,待生根放叶后,应该及时分苗上盆。播种的新苗，宜在成株时上盆。在多数宿根花卉,应在幼芽刚开始萌动时上盆。
//    /// </summary>
//    public string DailyMaintenance { get; set; }
//}

//public class Root
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public MainSceneTxtData MainSceneTxtData { get; set; }
//}