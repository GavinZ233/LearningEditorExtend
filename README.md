# LearningEditorExtend

Unity版本：`2021.3.11f1`

## **知识点**

### **自定义菜单栏拓展**

UnityEditor命名空间的脚本不可以被打包出去，需要放到`Editor`文件夹下



| 作用 | 写法  |  备注   |预览图|
| --- | ---  |  ---|---|
|  `编辑器顶部菜单栏`    |       [MenuItem("GavinTools/CreatLesson")]     ||
| 顶部菜单的GameObject和`Hierarchy右键菜单`     |      [MenuItem("GameObject/Lesson1/HierarchyFun")]|     ||
|  `Project右键菜单`    |      [MenuItem("Assets/Lesson1/AssetFun")] |    ||
|  `脚本右键菜单`    |     [MenuItem("CONTEXT/Lesson1_Test/Lesson1/BehaviourFun")]|    ||
|  顶部菜单的Component为目标GameObject添加脚本    | [AddComponentMenu("Unity编辑器拓展/添加脚本/Lesson1_Test")]|    using UnityEngine; 不支持快捷键 ||

### **快捷键**    

路径后 + 空格 + 下划线 + 想要的按键       
`单键`,需要在前面加下划线       
[MenuItem("Unity编辑器拓展/Lesson1/TestFun _u")]      
 `组合键`,不需要下划线     
[MenuItem("GameObject/Lesson1/HierarchyFun %#&B")]        
 
    % 表示ctrl
    # 表示shift
    & 表示alt   
    其他按键：
    LEFT、RIGHT：持类似#LEFT是左shift之类的按键
    UP、DOWN、F1..F12、HOME、END、PGUP、PGDN



### **自定义窗口拓展**

[EditorWindow官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/EditorWindow.html)

此处仅记录常用的

#### 常用变量    

| 名称 | 作用 | 备注 |      
| ---- | --- | ---|  
|autoRepaintOnSceneChange|窗口是否会在场景每次发生变化时自动重绘？||
|docked|是否停靠|停靠就是拖入编辑器其他模块里|
|minSize|限制窗口最小大小|position设置后此限制会失效|
|position|设置位置与大小||
|titleContent|设置窗口标题|可添加图标|
|hasUnsavedChanges|关闭窗口前是否提示用户保存信息||
|saveChangesMessage|提示保存信息的提示词||
|wantsMouseEnterLeaveWindow|如果设置为 true，则每当鼠标进入或离开窗口时，该窗口都会收到一次 OnGUI 调用|

#### 静态变量    
| 名称 | 作用 | 备注 |    
| ---- | --- | ---|  
|focusedWindow|当前已获得键盘焦点的 EditorWindow。（只读）||
|mouseOverWindow|当前在鼠标光标下的 EditorWindow。（只读）||

#### 静态函数


| 名称 | 作用 | 备注 |     
| ---- | --- | ---| 
|CreateWinow|创建窗口|
|FocusWindowIfItsOpen|聚焦发现的第一个指定类型的 EditorWindow（如果已打开）||
|GetWindow|返回当前屏幕上第一个 t 类型的 EditorWindow。|没有会自动创建|
|GetWindowWithRect|返回一个指定位置、大小的窗口|没有会自动创建|
|HasOpenInstances|检查T类型编辑器窗口是否已打开||


#### 成员函数

| 名称 | 作用 | 备注 |     
| ---- | --- | ---|  
|Show|显示弹窗||
|ShowModal|以独立模块打开弹窗，不可停靠||
|Focus|全体目光向我看齐||
|Repaint|重绘窗口|
|Close|关闭窗口||
|SaveChanges|点击确认保存时|继承的虚函数，需要自己写逻辑
|DiscardChanges|点击取消取消保存|同上

####  周期方法

| 名称 | 作用 | 备注 |     
| ---- | --- | ---|  
|Awake||同Monobehaviour|
|OnEnable|||
|OnGUI|||
|Update|||
|OnDisable|||
|OnDestroy|||

####  窗口事件回调

| 名称 | 作用 | 备注 |     
| ---- | --- | ---|  
|OnFocus|当窗口获得焦点时调用||
|OnLostFocus|当窗口失去焦点时调用||
|OnProjectChange|当项目资源发生变化时调用||
|OnInspectorUpdate|在Inspector面板更新时调用||
|OnSelectionChange|当选择的对象发生变化时调用||
|OnHierarchyChange|当Hierarchy发生变化时调用||


### **EditorGUILayout**
    
[EditorGUILayout官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/EditorGUILayout.html)




GUI 和 GUILayout 是用于绘制用户界面元素的类。它们都提供了一系列的静态方法，用于创建按钮、标签、文本框等UI元素。

GUI 类提供了一种基于坐标的绘制方法，允许你指定元素的位置和大小。

GUILayout 类则使用基于布局的方法，允许你创建自适应的UI元素，其位置和大小会根据屏幕大小和其他元素的变化而自动调整

EditorGUI 和 EditorGUILayout 是专门用于在Unity编辑器中创建自定义编辑器界面的类。

EditorGUI 提供了一组方法，允许你在编辑器中创建自定义的UI元素，例如字段、标签等。它提供了更高级的控制，适用于需要更灵活布局和样式的情况。

EditorGUILayout 则提供了一组适用于编辑器界面的方法。它简化了创建编辑器窗口的过程，使得在编辑器中布局UI变得更加容易。

可以认为 EditorGUI 提供了相对 GUI 更多的控件绘制API，专门提供于编辑器拓展使用，我们一般会将他们配合使用来进行编辑器拓展开发，而后面加了Layout的两个公共类只是多了自动布局功能。

#### 常用UI


|方法|写法|备注|效果|
|---|---|---|---|
|文本|EditorGUILayout.LabelField("111","22222");||
|层级选择|layer=EditorGUILayout.LayerField("这是层级",layer);||
|标签选择|tag=EditorGUILayout.TagField("tag:",tag);||
|颜色|color = EditorGUILayout.ColorField(new GUIContent("颜色："),color);|| 
|单选枚举|testType = (E_TestType)EditorGUILayout.EnumPopup("枚举：",testType);||
|多选枚举|mulType = (E_TestType)EditorGUILayout.EnumFlagsField("枚举多选：", mulType);||
|整数单选|selectInt = EditorGUILayout.IntPopup("整数单选：", selectInt, strs,ints);|传入int数组和string数组，string[]用来展示或解释整数的含义，选中string时，会选中其对应索引的整数|
|下拉式按钮|EditorGUILayout.DropdownButton(new GUIContent("按钮"),FocusType.Keyboard)|本身不能提供下拉列表，需要配合逻辑自己实现|
|连接按钮|EditorGUILayout.LinkButton("按钮")|样式为超链接的按钮，跳转连接逻辑需要自行实现|
|资源关联|obj = EditorGUILayout.ObjectField("关联Obj：",obj,typeof(GameObject),true) as GameObject;|自定义资源类型,可以点出搜索面板也可以拖动关联，通过第四个参数`allowSceneObjects`确认是否关联当前场景目标|
|单行输入框|inputInt = EditorGUILayout.IntField("Int输入：", inputInt);|支持int、string、float、double、long|
|延迟单行输入框|inputInt = EditorGUILayout.DelayedIntField("延迟Int：", inputInt);|输入的数据只有在输入框失去焦点时才会记录，支持int、string、float、double|
|多行文本输入框|inputStr = EditorGUILayout.TextArea(inputStr);|不设置大小时，默认会根据行数自动拓展高度|
|多维输入|inputV2 = EditorGUILayout.Vector2Field("V2输入：", inputV2);|支持vector2、3、4，rect、bound。以上都支持int和float|
|滑动条|sliderFloat = EditorGUILayout.Slider("slider:", sliderFloat, 0, 55);|支持int和float|
|双块滑动条|EditorGUILayout.MinMaxSlider("双块", ref rightSlider, ref leftSlider, 0, 12);|需要先声明两个float传入|
|空白组件|EditorGUILayout.Space(31);|夹在组件中间，自定义组件间间隔距离|
|动画曲线|curve = EditorGUILayout.CurveField("曲线：", curve);||
|复选框|toggle =EditorGUILayout.Toggle("Toggle：",toggle);||
|靠左复选框|toggle = EditorGUILayout.ToggleLeft("TogLeft", toggle);||
|复选折叠组|toggleGroup = EditorGUILayout.BeginToggleGroup("togGroup:",toggleGroup);EditorGUILayout.EndToggleGroup();|被begin和end包裹的代码会被togglegroup置灰，变得无法交互|
|下拉折叠|isHide = EditorGUILayout.Foldout(isHide, "折叠：", true);||
|下拉折叠豪华版|||
|排列布局|||
|滚动布局|||
|提示窗|||
||||


### GUILayout

[GUILayout官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/GUILayout.html)

#### GUILayoutOption
布局选项，在GUILayout方法入参后面添加的布局约束。   
如：

    layer=EditorGUILayout.LayerField("这是层级",layer,GUILayout.MaxWidth(321),GUILayout.MinHeight(56));



- 控件的固定宽高    
GUILayout.Width(300);   
GUILayout.Height(200);    
- 允许控件的最小宽高    
GUILayout.MinWidth(50);       
GUILayout.MinHeight(50);    
- 允许控件的最大宽高    
GUILayout.MaxWidth(100);    
GUILayout.MaxHeight(100);   
- 允许或禁止水平拓展    
GUILayout.ExpandWidth(true);//允许    
GUILayout.ExpandHeight(false);//禁止    
GUILayout.ExpandHeight(true);//允许     
GUILayout.ExpandHeight(false);//禁止    


### 常用UI

此处只考虑在EditorWindow下的效果

|方法|写法|备注|效果|
|---|---|---|---|
|文本|||
|层级选择|||
|标签选择|||
|颜色|||
|枚举|||
||||

| **方法**                | **描述**                                            | **示例代码**                                                     |
|-------------------------|-----------------------------------------------------|------------------------------------------------------------------|
| Label()               | 显示一个标签。                                      | GUILayout.Label("This is a label.");                           |
| Box()                 | 显示一个框，用于分组或描述区域。                    | GUILayout.Box("This is a box.");                               |
| Button()              | 创建一个按钮。                                      | if (GUILayout.Button("Click Me")) { Debug.Log("Button Clicked"); } |
| RepeatButton()        | 创建一个重复按钮，按住时会重复触发事件。            | if (GUILayout.RepeatButton("Hold Me")) { Debug.Log("Holding"); } |
| TextField()           | 创建一个单行文本输入框。                            | string text = GUILayout.TextField(text);                       |
| TextArea()            | 创建一个多行文本输入框。                            | string text = GUILayout.TextArea(text);                        |
| PasswordField()       | 创建一个密码输入框，输入内容会以 * 显示。         | string password = GUILayout.PasswordField(password, '*');      |
| Toggle()              | 创建一个布尔开关。                                  | bool isOn = GUILayout.Toggle(isOn, "Toggle");                  |
| Toolbar()             | 创建一个工具栏。                                    | selected = GUILayout.Toolbar(selected, new string[] { "A", "B", "C" }); |
| SelectionGrid()       | 创建一个选择网格。                                  | selected = GUILayout.SelectionGrid(selected, new string[] { "A", "B", "C" }, 2); |
| HorizontalSlider()    | 创建一个水平滑动条。                                | float value = GUILayout.HorizontalSlider(value, 0, 10);        |
| VerticalSlider()      | 创建一个垂直滑动条。                                | float value = GUILayout.VerticalSlider(value, 0, 10);          |
| HorizontalScrollbar() | 创建一个水平滚动条。                                | scrollPosition = GUILayout.HorizontalScrollbar(scrollPosition, 1, 0, 10); |
| VerticalScrollbar()   | 创建一个垂直滚动条。                                | scrollPosition = GUILayout.VerticalScrollbar(scrollPosition, 1, 0, 10); |
| Space()               | 添加一个固定大小的空白区域。                        | GUILayout.Space(20);                                           |
| FlexibleSpace()       | 添加一个可扩展的空白区域。                          | GUILayout.FlexibleSpace();                                     |
| BeginHorizontal()     | 开始一个水平布局组。                                | GUILayout.BeginHorizontal();                                   |
| EndHorizontal()       | 结束一个水平布局组。                                | GUILayout.EndHorizontal();                                     |
| BeginVertical()       | 开始一个垂直布局组。                                | GUILayout.BeginVertical();                                     |
| EndVertical()         | 结束一个垂直布局组。                                | GUILayout.EndVertical();                                       |
| BeginArea()           | 开始一个具有特定矩形区域的布局组。                  | GUILayout.BeginArea(new Rect(10, 10, 200, 200));               |
| EndArea()             | 结束一个区域布局组。                                | GUILayout.EndArea();                                           |
| BeginScrollView()     | 开始一个滚动视图。                                  | scrollPosition = GUILayout.BeginScrollView(scrollPosition);    |
| EndScrollView()       | 结束一个滚动视图。                                  | GUILayout.EndScrollView();                                     |
| Width()               | 设置控件的宽度。                                    | GUILayout.Width(100);                                          |
| Height()              | 设置控件的高度。                                    | GUILayout.Height(30);                                          |
| ExpandWidth()         | 控件是否应根据剩余空间扩展其宽度。                  | GUILayout.ExpandWidth(true);                                   |
| ExpandHeight()        | 控件是否应根据剩余空间扩展其高度。                  | GUILayout.ExpandHeight(true);                                  |
| MaxWidth()            | 控件的最大宽度。                                    | GUILayout.MaxWidth(200);                                       |
| MaxHeight()           | 控件的最大高度。                                    | GUILayout.MaxHeight(50);                                       |
| MinWidth()            | 控件的最小宽度。                                    | GUILayout.MinWidth(50);                                        |
| MinHeight()           | 控件的最小高度。                                    | GUILayout.MinHeight(20);                                       |





- **EditorGUIUtility公共类**

  - **EditorGUIUtility是什么**

  - **资源加载**

  - **搜索框查询、对象选中提示**

  - **窗口事件传递、坐标转换**

  - **指定区域使用对应鼠标指针**

  - **绘制色板、绘制曲线**

### **Selection公共类**

- **Selection是什么**

- **常用静态成员**

- **常用静态方法**

### **Event公共类**

### **Inspector窗口拓展**

- **基础知识**

- **数组、List属性**

- **自定义属性**

- **字典属性**

### **Scene窗口拓展**

- **Handles公共类**

  - **Handles类是什么及响应函数**

  - **文本、线段、虚线**

  - **弧线、圆、立方体，几何体**

  - **移动、旋转、缩放**

  - **自由移动、自由旋转**

  - **显示GUI**

- **HandleUtility公共类**

- **Gizmos公共类**

  - **Gizmos类是什么及响应函数**

  - **颜色、立方体、视锥**

  - **贴图、图标**

  - **线段、网格、射线**

  - **球体、网格线**

### **EditorUtility公共类**

- **EditorUtility是什么**

- **编辑器默认窗口相关**

- **文件面板相关**

- **其他内容**

### **AssetDatabase公共类**

- **AssetDatabase是什么**

- **AssetDatabase中的常用API**

### **更多内容**

- **PrefabUtility公共类**

- **EditorApplication公共类**

- **CompilationPipeline公共类**

- **AssetImporter和AssetPostprocessor**

## **实践**

### **1.需求分析**

- 1.右键选中对象，可以在UI页签中添加新功能

  -  

  -  知识点运用：
     自定义菜单栏拓展

- 2.点击该按钮后，会弹出自定义窗口

  -  

  -  知识点运用：
     自定义窗口拓展

- 3.显示的窗口中，会显示将要自动生成的代码内容

  - 知识点运用：
    1.EditorGUI、GUI等控件功能
    2.Selection公共类
    3.AssetDatabase公共类
    等

- 4.点击选择路径保存按钮后，会弹出保存窗口

  -  

  -  知识点运用：
     EditorUtility公共类

- 5.点击保存后，会动态创建两个脚本文件，并且会讲脚本添加到选中对象上

  -  

  -  

  -  知识点运用：
     1.AssetDatabase公共类
     2.CompilationPipeline公共类
     3.EditorApplicationg公共类

### **2.基本工具流程实现**

- 1.创建项目

- 2.添加编辑器拓展功能

  - 自定义右键菜单

  - 打开自定义面板

  - 自定义面板打开文件保存面板

### **3.脚本模板配置**

- 1.分析主要目的

  - 模拟UI功能开发流程

  - 主要流程

    - 拼面板

    - 写面板脚本

      - 找到控件

      - 监听事件

    - 处理面板逻辑

- 2.基于主要目的配置模板

### **4.拼接数据结构**

- 根据上节课的配置模板的结构可以知道
  之后我们主要需要动态生成的内容分成以下四部分
  1.控件声明
  2.控件查找
  3.控件事件监听
  4.控件事件响应函数

会不停的查找控件
不停的拼接这四部分的内容
最终插入拼接到这个模板文件中

因此我们可以声明一个数据结构类
用来表示一个控件的这四个部分，方便我们进行拼接

### **5.控件查找**

- 1.获取选择的对象

- 2.获取选择的对象下的相关UI控件

- 3.将相关逻辑封装成对应方法

### **6.重复无用判断**

- 1.不用的控件，不记录。
  可以自己定规则决定什么控件是不用的
  比如，控件名是默认名就认为不会专门使用它们

- 2.重复名字的控件，不记录。
  可以自己定规则，比如要使用的控件不能够重名

- 3.如果同一个对象上，有两种UI控件，记录更重要的

### **7.子对象嵌套**

- 解决控件有父对象的情况

### **8.结构数据拼接**

- 查找所有控件
  拼接所有字符串

### **9.组装模板**

- 读取模板文件
  将获取的字符串插入拼接进去

### **10.窗口界面布局**

### **11.脚本保存**

### **12.脚本动态添加**

### **13.功能测试**

- 1.如果存在同名控件生成失败的问题处理

- 2.如果开着面板又生成其它内容问题处理

