# LearningEditorExtend

![Static Badge](https://img.shields.io/badge/Unity-2021.3.11f1-blue)


## **知识点**

### **自定义菜单栏拓展**

UnityEditor命名空间的脚本不可以被打包出去，需要放到`Editor`文件夹下



| 作用                                        | 写法                                                        | 备注                            |
| ------------------------------------------- | ----------------------------------------------------------- | ------------------------------- |
| `编辑器顶部菜单栏`                          | [MenuItem("GavinTools/CreatLesson")]                        |                                 |
| 顶部菜单的GameObject和`Hierarchy右键菜单`   | [MenuItem("GameObject/Lesson1/HierarchyFun")]               |                                 |
| `Project右键菜单`                           | [MenuItem("Assets/Lesson1/AssetFun")]                       |                                 |
| `脚本右键菜单`                              | [MenuItem("CONTEXT/Lesson1_Test/Lesson1/BehaviourFun")]     |                                 |
| 顶部菜单的Component为目标GameObject添加脚本 | [AddComponentMenu("Unity编辑器拓展/添加脚本/Lesson1_Test")] | using UnityEngine; 不支持快捷键 |

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

| 名称                       | 作用                                                                       | 备注                         |
| -------------------------- | -------------------------------------------------------------------------- | ---------------------------- |
| autoRepaintOnSceneChange   | 窗口是否会在场景每次发生变化时自动重绘？                                   |                              |
| docked                     | 是否停靠                                                                   | 停靠就是拖入编辑器其他模块里 |
| minSize                    | 限制窗口最小大小                                                           | position设置后此限制会失效   |
| position                   | 设置位置与大小                                                             |                              |
| titleContent               | 设置窗口标题                                                               | 可添加图标                   |
| hasUnsavedChanges          | 关闭窗口前是否提示用户保存信息                                             |                              |
| saveChangesMessage         | 提示保存信息的提示词                                                       |                              |
| wantsMouseEnterLeaveWindow | 如果设置为 true，则每当鼠标进入或离开窗口时，该窗口都会收到一次 OnGUI 调用 |

#### 静态变量    
| 名称            | 作用                                        | 备注 |
| --------------- | ------------------------------------------- | ---- |
| focusedWindow   | 当前已获得键盘焦点的 EditorWindow。（只读） |      |
| mouseOverWindow | 当前在鼠标光标下的 EditorWindow。（只读）   |      |

#### 静态函数


| 名称                 | 作用                                                  | 备注           |
| -------------------- | ----------------------------------------------------- | -------------- |
| CreateWinow          | 创建窗口                                              |
| FocusWindowIfItsOpen | 聚焦发现的第一个指定类型的 EditorWindow（如果已打开） |                |
| GetWindow            | 返回当前屏幕上第一个 t 类型的 EditorWindow。          | 没有会自动创建 |
| GetWindowWithRect    | 返回一个指定位置、大小的窗口                          | 没有会自动创建 |
| HasOpenInstances     | 检查T类型编辑器窗口是否已打开                         |                |


#### 成员函数

| 名称           | 作用                         | 备注                         |
| -------------- | ---------------------------- | ---------------------------- |
| Show           | 显示弹窗                     |                              |
| ShowModal      | 以独立模块打开弹窗，不可停靠 |                              |
| Focus          | 全体目光向我看齐             |                              |
| Repaint        | 重绘窗口                     |
| Close          | 关闭窗口                     |                              |
| SaveChanges    | 点击确认保存时               | 继承的虚函数，需要自己写逻辑 |
| DiscardChanges | 点击取消取消保存             | 同上                         |

####  周期方法

| 名称      | 作用 | 备注            |
| --------- | ---- | --------------- |
| Awake     |      | 同Monobehaviour |
| OnEnable  |      |                 |
| OnGUI     |      |                 |
| Update    |      |                 |
| OnDisable |      |                 |
| OnDestroy |      |                 |

####  窗口事件回调

| 名称              | 作用                       | 备注 |
| ----------------- | -------------------------- | ---- |
| OnFocus           | 当窗口获得焦点时调用       |      |
| OnLostFocus       | 当窗口失去焦点时调用       |      |
| OnProjectChange   | 当项目资源发生变化时调用   |      |
| OnInspectorUpdate | 在Inspector面板更新时调用  |      |
| OnSelectionChange | 当选择的对象发生变化时调用 |      |
| OnHierarchyChange | 当Hierarchy发生变化时调用  |      |


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


| 方法           | 写法                                                                                                                    | 备注                                                                                                     | 效果                                                                                                |
| -------------- | ----------------------------------------------------------------------------------------------------------------------- | :------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| 文本           | EditorGUILayout.LabelField("111","22222");                                                                              |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/label.png)        |
| 层级选择       | layer=EditorGUILayout.LayerField("这是层级",layer);                                                                     |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/layer.png)        |
| 标签选择       | tag=EditorGUILayout.TagField("tag:",tag);                                                                               |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/tag.png)          |
| 颜色           | color = EditorGUILayout.ColorField(new GUIContent("颜色："),color);                                                     |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/color.png)        |
| 单选枚举       | testType = (E_TestType)EditorGUILayout.EnumPopup("枚举：",testType);                                                    |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/enumsin.png)      |
| 多选枚举       | mulType = (E_TestType)EditorGUILayout.EnumFlagsField("枚举多选：", mulType);                                            |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/enummul.png )     |
| 整数单选       | selectInt = EditorGUILayout.IntPopup("整数单选：", selectInt, strs,ints);                                               | 传入int数组和string数组，string[]用来展示或解释整数的含义，选中string时，会选中其对应索引的整数          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/intpopup.png)     |
| 下拉式按钮     | EditorGUILayout.DropdownButton(new GUIContent("按钮"),FocusType.Keyboard)                                               | 本身不能提供下拉列表，需要配合逻辑自己实现                                                               | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/dropdownbtn.png)  |
| 连接按钮       | EditorGUILayout.LinkButton("按钮")                                                                                      | 样式为超链接的按钮，跳转连接逻辑需要自行实现                                                             | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/linkbtn.png)      |
| 资源关联       | obj = EditorGUILayout.ObjectField("关联Obj：",obj,typeof(GameObject),true) as GameObject;                               | 自定义资源类型,可以点出搜索面板也可以拖动关联，通过第四个参数`allowSceneObjects`确认是否关联当前场景目标 | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/objfield.png)     |
| 单行输入框     | inputInt = EditorGUILayout.IntField("Int输入：", inputInt);                                                             | 支持int、string、float、double、long                                                                     | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/field.png)        |
| 延迟单行输入框 | inputInt = EditorGUILayout.DelayedIntField("延迟Int：", inputInt);                                                      | 输入的数据只有在输入框失去焦点时才会记录，支持int、string、float、double                                 | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/delayfield.png)   |
| 多行文本输入框 | inputStr = EditorGUILayout.TextArea(inputStr);                                                                          | 不设置大小时，默认会根据行数自动拓展高度                                                                 | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/textarea.png)     |
| 多维输入       | inputV2 = EditorGUILayout.Vector2Field("V2输入：", inputV2);                                                            | 支持vector2、3、4，rect、bound。以上都支持int和float                                                     | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/vectorfield.png)  |
| 滑动条         | sliderFloat = EditorGUILayout.Slider("slider:", sliderFloat, 0, 55);                                                    | 支持int和float                                                                                           | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/fslider.png)      |
| 双块滑动条     | EditorGUILayout.MinMaxSlider("双块", ref rightSlider, ref leftSlider, 0, 12);                                           | 需要先声明两个float传入                                                                                  | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/doubleslider.png) |
| 空白组件       | EditorGUILayout.Space(31);                                                                                              | 夹在组件中间，自定义组件间间隔距离                                                                       |                                                                                                     |
| 动画曲线       | curve = EditorGUILayout.CurveField("曲线：", curve);                                                                    |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/curve.png)        |
| 复选框         | toggle =EditorGUILayout.Toggle("Toggle：",toggle);                                                                      |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/togGroup.png)     |
| 靠左复选框     | toggle = EditorGUILayout.ToggleLeft("TogLeft", toggle);                                                                 |                                                                                                          | 同上                                                                                                |
| 复选折叠组     | toggleGroup = EditorGUILayout.BeginToggleGroup("togGroup:",toggleGroup);EditorGUILayout.EndToggleGroup();               | 被begin和end包裹的代码false时会被togglegroup置灰，变得无法交互                                           | 同上                                                                                                |
| 下拉折叠       | isHide = EditorGUILayout.Foldout(isHide, "折叠：", true);                                                               |                                                                                                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/foldout.png)      |
| 下拉折叠豪华版 | isHideGroup = EditorGUILayout.BeginFoldoutHeaderGroup(isHideGroup, "折叠组：");EditorGUILayout.EndFoldoutHeaderGroup(); | 比普通的多了选中变色加粗，写法是两行但没有代码包裹效果                                                   | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/foldout2.png)     |
| 排列布局       | EditorGUILayout.BeginHorizontal();EditorGUILayout.EndHorizontal();                                                      | 被包裹的代码会水平(Horizontal)或者垂直(Vertical)排列                                                     | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/helpbox.png)      |
| 滚动布局       | scrollView = EditorGUILayout.BeginScrollView(scrollView);EditorGUILayout.EndScrollView();                               | 包裹的代码会在滚动视图内，根据窗口大小自动调节                                                           | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/scrollview.png)   |
| 提示窗         | EditorGUILayout.HelpBox("tishi", MessageType.None);                                                                     | MessageType四种类型None、Info、Warning、Error                                                            | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gui/helpbox.png)      |



### **GUILayout**

[GUILayout官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/GUILayout.html)

#### GUILayoutOption
布局选项，在GUILayout方法入参后面添加的布局约束。可以应用到EditorGUILayout中   
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
GUILayout.ExpandWidth(true);    
GUILayout.ExpandHeight(false);




### **GUILayout组件**



| **方法**              | **描述**                                  | **示例代码**                                                                     |
| --------------------- | ----------------------------------------- | -------------------------------------------------------------------------------- |
| Label()               | 显示一个标签。                            | GUILayout.Label("This is a label.");                                             |
| Box()                 | 显示一个框，用于分组或描述区域。          | GUILayout.Box("This is a box.");                                                 |
| `Button()`            | 创建一个按钮。                            | if (GUILayout.Button("Click Me")) { Debug.Log("Button Clicked"); }               |
| `RepeatButton()`      | 创建一个重复按钮，按住时会重复触发事件。  | if (GUILayout.RepeatButton("Hold Me")) { Debug.Log("Holding"); }                 |
| TextField()           | 创建一个单行文本输入框。                  | string text = GUILayout.TextField(text);                                         |
| TextArea()            | 创建一个多行文本输入框。                  | string text = GUILayout.TextArea(text);                                          |
| `PasswordField()`     | 创建一个密码输入框，输入内容会以 * 显示。 | string password = GUILayout.PasswordField(password, '*');                        |
| Toggle()              | 创建一个布尔开关。                        | bool isOn = GUILayout.Toggle(isOn, "Toggle");                                    |
| Toolbar()             | 创建一个工具栏。                          | selected = GUILayout.Toolbar(selected, new string[] { "A", "B", "C" });          |
| SelectionGrid()       | 创建一个选择网格。                        | selected = GUILayout.SelectionGrid(selected, new string[] { "A", "B", "C" }, 2); |
| HorizontalSlider()    | 创建一个水平滑动条。                      | float value = GUILayout.HorizontalSlider(value, 0, 10);                          |
| VerticalSlider()      | 创建一个垂直滑动条。                      | float value = GUILayout.VerticalSlider(value, 0, 10);                            |
| HorizontalScrollbar() | 创建一个水平滚动条。                      | scrollPosition = GUILayout.HorizontalScrollbar(scrollPosition, 1, 0, 10);        |
| VerticalScrollbar()   | 创建一个垂直滚动条。                      | scrollPosition = GUILayout.VerticalScrollbar(scrollPosition, 1, 0, 10);          |
| Space()               | 添加一个固定大小的空白区域。              | GUILayout.Space(20);                                                             |
| FlexibleSpace()       | 添加一个可扩展的空白区域。                | GUILayout.FlexibleSpace();                                                       |
| BeginHorizontal()     | 开始一个水平布局组。                      | GUILayout.BeginHorizontal();                                                     |
| EndHorizontal()       | 结束一个水平布局组。                      | GUILayout.EndHorizontal();                                                       |
| BeginVertical()       | 开始一个垂直布局组。                      | GUILayout.BeginVertical();                                                       |
| EndVertical()         | 结束一个垂直布局组。                      | GUILayout.EndVertical();                                                         |
| BeginArea()           | 开始一个具有特定矩形区域的布局组。        | GUILayout.BeginArea(new Rect(10, 10, 200, 200));                                 |
| EndArea()             | 结束一个区域布局组。                      | GUILayout.EndArea();                                                             |
| BeginScrollView()     | 开始一个滚动视图。                        | scrollPosition = GUILayout.BeginScrollView(scrollPosition);                      |
| EndScrollView()       | 结束一个滚动视图。                        | GUILayout.EndScrollView();                                                       |


### **EditorGUIUtility**

[EditorGUIUtility官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/EditorGUIUtility.html)       

工具类加载的资源需要在一级文件夹`Editor Default Resources`内寻找。    

仅记录常用

| **方法/属性**      | **描述**                                 | **示例**                                                                        |
| ------------------ | ---------------------------------------- | ------------------------------------------------------------------------------- |
| LoadRequired()     | 加载资源需要填写后缀，不存在的资源`报错` | Texture2D tex = EditorGUIUtility.LoadRequired("Icons/MyIcon.png") as Texture2D; |
| Load()             | 加载资源需要填写后缀，不存在的资源`返空` | Texture2D tex = EditorGUIUtility.Load("Assets/MyIcon.png") as Texture2D;        |
| ShowObjectPicker() | 弹出目标资源搜索框                       | EditorGUIUtility.ShowObjectPicker<Texture>(null,true,"pdf",0);                  |
| PingObject()       | 在编辑器中高亮显示并选中对象。           | EditorGUIUtility.PingObject(myObject);                                          |
| AddCursorRect()    | 将鼠标光标矩形区域添加到事件队列中。     | EditorGUIUtility.AddCursorRect(rect, MouseCursor.ResizeHorizontal);             |
| FindTexture()      | 根据名称查找内置或自定义资源中的纹理。   | Texture2D texture = EditorGUIUtility.FindTexture("d_console.warnicon");         |
| DrawColorSwatch()  | 将颜色和透明的信息展示成一张图           | color=EditorGUILayout.ColorField(new GUIContent("颜色"),color,true,true,true);  |
| DrawCurveSwatch()  | 将曲线展示成一张图                       | curve = EditorGUILayout.CurveField("曲线",curve);                               |
| GUIToScreenPoint() | 将一个点从GUI转换到屏幕空间              | Vector2 screenPos = EditorGUIUtility.GUIToScreenPoint(v);                       |
| ScreenToGUIPoint() | 将屏幕空间的点转换到GUI空间              | Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);               |


  屏幕空间y坐标从窗口顶部边缘的零到窗口底部边缘的最大值不等，在坐标转换时会有一定的偏移。

### **Selection**


| **方法/属性**      | **描述**                             | **示例代码**                                                                       |
| ------------------ | ------------------------------------ | ---------------------------------------------------------------------------------- |
| `activeObject`     | 获取或设置当前选中的第一个对象。     | Selection.activeObject = myGameObject;                                             |
| `activeGameObject` | 获取或设置当前选中的第一个游戏对象。 | Selection.activeGameObject = myGameObject;                                         |
| activeTransform    | 获取或设置当前选中的第一个变换对象。 | Selection.activeTransform = myTransform;                                           |
| objects            | 获取或设置当前选中的对象数组。       | Selection.objects = new Object[] { obj1, obj2 };                                   |
| count              | 获取当前选中的object总数             | Selection.count                                                                    |
| `gameObjects`      | 获取或设置当前选中的游戏对象数组。   | Selection.gameObjects = new GameObject[] { go1, go2 };                             |
| transforms         | 获取或设置当前选中的变换对象数组。   | Selection.transforms = new Transform[] { trans1, trans2 };                         |
| assetGUIDs         | 获取当前选中的资源的 GUID 数组。     | string[] guids = Selection.assetGUIDs;                                             |
| `Contains()`       | 检查当前选中对象是否包含指定对象。   | bool isSelected = Selection.Contains(myObject);                                    |
| `GetFiltered()`    | 获取过滤后的选中对象数组。           | Transform[] transforms = Selection.GetFiltered<Transform>(SelectionMode.Editable); |
| selectionChanged   | 当选中的对象改变时触发的事件。       | Selection.selectionChanged += MySelectionChangedMethod;                            |

其中GetFiltered方法需要传入的筛选枚举     

| **枚举**      | **描述**                          |
| ------------- | --------------------------------- |
| Unfiltered    | 不过滤                            |
| TopLevel      | 仅返回父对象(Transform)           |
| Deep          | 返回选择内容及其子对象(Transform) |
| ExcludePrefab | 排除预制体                        |
| Editable      | 只返回可编辑的内容                |
| Assets        | 仅返回Asset目录的资产对象         |
| DeepAssets    | 同时获取子文件夹的内容            |

> 默认的变换选择模式为：SelectionMode.TopLevel | SelectionMode.ExcludePrefab | SelectionMode.Editable。


### **Event公共类**
[Event官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/Event.html)       

**Event**
| **属性/方法**     | **描述**                                                |
| ----------------- | ------------------------------------------------------- |
| `current`         | 当前正在处理的事件。以下操作都是对Event.current进行访问 |
| `alt`             | 是否按下 Alt/Option 键？（只读）                        |
| `button`          | 按下的鼠标按钮。                                        |
| `capsLock`        | 是否打开大写锁定？（只读）                              |
| `character`       | 输入的字符。                                            |
| `clickCount`      | 连续点击的次数。                                        |
| command           | 是否按下 Command/Windows 键？（只读）                   |
| `commandName`     | 执行或验证命令事件的名称。                              |
| `control`         | 是否按下 Control 键？（只读）                           |
| `shift`           | 是否按下 Shift 键？（只读）                             |
| delta             | 鼠标相对于上次事件的移动量。                            |
| displayIndex      | 事件所属显示器的索引。                                  |
| functionKey       | 当前按键是否是功能键？（只读）                          |
| isKey             | 该事件是否是键盘事件？（只读）                          |
| isMouse           | 该事件是否是鼠标事件？（只读）                          |
| `keyCode`         | 键盘事件的原始键码。                                    |
| modifiers         | 按下的修饰键。                                          |
| `mousePosition`   | 鼠标位置。                                              |
| numeric           | 当前按键是否在数字键盘上？（只读）                      |
| pointerType       | 创建该事件的指针类型（例如：鼠标、触摸屏、笔）。        |
| pressure          | 施加的笔压力。                                          |
| `type`            | 事件的类型。                                            |
| GetTypeForControl | 获取给定控件 ID 的过滤事件类型。                        |
| `Use`             | 使用此事件。                                            |
| GetEventCount     | 返回事件队列中存储的事件数量。                          |
| KeyboardEvent     | 创建一个键盘事件。                                      |
| PopEvent          | 从事件系统中获取下一个排队的事件。                      |


>commandName有"Copy", "Cut", "Paste", "Delete", "FrameSelected", "Duplicate", "SelectAll" 等等



**EventType**

| **事件类型**     | **描述**                                       |
| ---------------- | ---------------------------------------------- |
| MouseDown        | 鼠标按下。                                     |
| MouseUp          | 鼠标释放。                                     |
| MouseMove        | 鼠标移动（仅限编辑器视图）。                   |
| MouseDrag        | 鼠标拖拽。                                     |
| KeyDown          | 键盘按键按下。                                 |
| KeyUp            | 键盘按键释放。                                 |
| ScrollWheel      | 滚轮滚动。                                     |
| Repaint          | 重绘事件。每帧发送一次。                       |
| Layout           | 布局事件。                                     |
| DragUpdated      | 编辑器中：拖放操作更新。                       |
| DragPerform      | 编辑器中：拖放操作执行。                       |
| DragExited       | 编辑器中：拖放操作退出。                       |
| Ignore           | 事件应被忽略。                                 |
| Used             | 事件已被处理。                                 |
| ValidateCommand  | 验证特殊命令（如复制粘贴）。                   |
| ExecuteCommand   | 执行特殊命令（如复制粘贴）。                   |
| ContextClick     | 用户右键单击（或在 Mac 上按 Control 键单击）。 |
| MouseEnterWindow | 鼠标进入窗口（仅限编辑器视图）。               |
| MouseLeaveWindow | 鼠标离开窗口（仅限编辑器视图）。               |
| TouchDown        | 直接操作设备（手指、笔）触摸屏幕。             |
| TouchUp          | 直接操作设备（手指、笔）离开屏幕。             |
| TouchMove        | 直接操作设备（手指、笔）在屏幕上移动（拖拽）。 |
| TouchEnter       | 直接操作设备（手指、笔）移动进入窗口（拖拽）。 |
| TouchLeave       | 直接操作设备（手指、笔）移动离开窗口（拖拽）。 |
| TouchStationary  | 直接操作设备（手指、笔）静止事件（长按）。     |


### **Inspector窗口拓展**

[SerializedObject官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/SerializedObject.html)       
[SerializedProperty官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/SerializedProperty.html)       


#### 拓展流程

1. 创建目标脚本的拓展脚本 Lesson22_InspectorEditor : Editor    
2. 拓展脚本声明特性 [CustomEditor(typeof(Lesson22_Inspector))]
3. 在拓展脚本声明使用的属性 private SerializedProperty atk;
4. 拓展脚本的`OnEnable`做属性关联 atk = serializedObject.FindProperty("atk");
5. 拓展脚本的`OnInspectorGUI` 声明新的展示逻辑,使用代码块包裹     
    serializedObject.Update();   
    serializedObject.ApplyModifiedProperties();




#### SerializedObject
序列化对象    
用于表示和管理一个或多个对象的序列化数据。它允许在编辑器中对对象属性进行统一管理和修改。常用的功能包括：  
1. 检查和编辑对象的属性。
2. 支持多对象编辑。
3. 应用和撤销修改。


###### 变量
| **变量**                    | **描述**                                                                           |
| --------------------------- | ---------------------------------------------------------------------------------- |
| context                     | 用于存储和解析 ExposedReference 类型的上下文。这由 SerializedObject 构造函数设置。 |
| forceChildVisibility        | 控制子隐藏字段的可见性。                                                           |
| hasModifiedProperties       | 如果 SerializedObject 的某个属性已经修改但尚未应用，则为 true。                    |
| isEditingMultipleObjects    | 序列化对象是否由于多对象编辑而代表多个对象？（只读）                               |
| maxArraySizeForMultiEditing | 定义大小上限，若在选择多个对象时超过该大小，则无法编辑数组。                       |
| targetObject                | 所检查的单个对象（只读）。                                                         |
| targetObjects               | 所检查的多个对象（只读）。                                                         |

###### 公共函数
| **函数**                              | **描述**                                                                                   |
| ------------------------------------- | ------------------------------------------------------------------------------------------ |
| ApplyModifiedProperties               | 应用属性修改。                                                                             |
| ApplyModifiedPropertiesWithoutUndo    | 在不注册撤销操作的情况下应用属性修改。                                                     |
| CopyFromSerializedProperty            | 将 SerializedProperty 中的值复制到序列化对象上的相应序列化属性。                           |
| CopyFromSerializedPropertyIfDifferent | 将 SerializedProperty 中的更改值复制到序列化对象上的相应序列化属性。                       |
| FindProperty                          | 按名称查找序列化属性。                                                                     |
| GetIterator                           | 获取第一个序列化属性。                                                                     |
| SetIsDifferentCacheDirty              | 在下一次进行 Update() 调用时更新 hasMultipleDifferentValues 缓存。                         |
| Update                                | 更新序列化对象的表示形式。                                                                 |
| UpdateIfRequiredOrScript              | 更新序列化对象的表示形式（仅当自上次调用 Update 后对象发生修改或者它是脚本时才进行更新）。 |


#### SerializedProperty
序列化属性
##### 变量

| **变量**                      | **描述**                                                                                             |
| ----------------------------- | ---------------------------------------------------------------------------------------------------- |
| animationCurveValue           | 动画曲线属性的值。                                                                                   |
| quaternionValue               | 四元数属性的值。                                                                                     |
| rectIntValue                  | 带有整数值属性的矩形的值。                                                                           |
| rectValue                     | 矩形属性的值。                                                                                       |
| `boolValue`                   | 布尔值属性的值。                                                                                     |
| boundsIntValue                | 带有整数值属性的边界的值。                                                                           |
| boundsValue                   | 边界属性的值。                                                                                       |
| `colorValue`                  | 颜色属性的值。                                                                                       |
| `doubleValue`                 | 双精度浮点属性的值。                                                                                 |
| `floatValue`                  | 浮点属性的值。                                                                                       |
| `intValue`                    | 整数属性的值。                                                                                       |
| `longValue`                   | 长整型属性的值。                                                                                     |
| `stringValue`                 | 字符串属性的值。                                                                                     |
| vector2IntValue               | 2D 整数向量属性的值。                                                                                |
| vector2Value                  | 2D 向量属性的值。                                                                                    |
| vector3IntValue               | 3D 整数向量属性的值。                                                                                |
| vector3Value                  | 3D 向量属性的值。                                                                                    |
| vector4Value                  | 4D 向量属性的值。                                                                                    |
| enumDisplayNames              | 枚举属性的枚举的友好显示名称。                                                                       |
| enumNames                     | 枚举属性的枚举的名称。                                                                               |
| enumValueFlag                 | 枚举属性的整数表示值，包含混合值。                                                                   |
| enumValueIndex                | 枚举属性的枚举索引。                                                                                 |
| hash128Value                  | Hash128 属性的值。                                                                                   |
| objectReferenceValue          | 对象引用属性的值。                                                                                   |
| arrayElementType              | 数组属性中元素的类型名称。（只读）                                                                   |
| arraySize                     | 数组中的元素数量。                                                                                   |
| depth                         | 属性的嵌套深度。（只读）                                                                             |
| displayName                   | 属性的友好显示名称。（只读）                                                                         |
| editable                      | 此属性是否可编辑？（只读）                                                                           |
| exposedReferenceValue         | 对场景中另一个对象的引用。系统将在包含 SerializedProperty 的 SerializedObject 的上下文中解析此引用。 |
| fixedBufferSize               | 固定缓冲区中的元素数量。（只读）                                                                     |
| hasChildren                   | 此属性是否有子属性？（只读）                                                                         |
| hasMultipleDifferentValues    | 此属性是否会因为多对象编辑而代表多个不同的值？（只读）                                               |
| hasVisibleChildren            | 此属性是否有可见的子属性？（只读）                                                                   |
| isArray                       | 此属性是否为数组？（只读）                                                                           |
| isDefaultOverride             | 允许检查此属性是否为默认重载。                                                                       |
| isExpanded                    | 此属性是否在检视面板中展开？                                                                         |
| isFixedBuffer                 | 此属性是否为固定缓冲区？（只读）                                                                     |
| isInstantiatedPrefab          | 属性是否为预制件实例的一部分？（只读）                                                               |
| managedReferenceFieldTypename | 与托管引用字段完整类型字符串的值对应的字符串。                                                       |
| managedReferenceFullTypename  | 与托管引用对象（动态）完整类型字符串的值对应的字符串。                                               |
| managedReferenceId            | 与托管引用关联的 ID。                                                                                |
| managedReferenceValue         | 分配给带 SerializeReference 属性字段的对象。                                                         |
| minArraySize                  | 所有目标对象中数组的最小元素数。（只读）                                                             |
| name                          | 属性的名称。（只读）                                                                                 |
| prefabOverride                | 允许检查属性的值是否被重载（即与其所属的预制件不同）。                                               |
| propertyPath                  | 属性的完整路径。（只读）                                                                             |
| propertyType                  | 此属性的类型（只读）。                                                                               |
| serializedObject              | 此属性所属的 SerializedObject（只读）。                                                              |
| tooltip                       | 属性的工具提示。（只读）                                                                             |
| type                          | 属性的类型名称。（只读）                                                                             |

##### 公共函数

| **函数**                       | **描述**                                                                                                           |
| ------------------------------ | ------------------------------------------------------------------------------------------------------------------ |
| ClearArray                     | 从数组中删除所有元素。                                                                                             |
| Copy                           | 返回 SerializedProperty 迭代器的副本（保留当前状态）。如果您想在继续迭代的同时保存当前属性的引用，则此方法很有用。 |
| CountInProperty                | 计算此属性的可见子属性的数量，包括属性本身。                                                                       |
| CountRemaining                 | 计算剩余可见属性的数量。                                                                                           |
| `DeleteArrayElementAtIndex`    | 删除数组中指定索引处的元素。                                                                                       |
| DeleteCommand                  | 删除已序列化的属性。                                                                                               |
| DuplicateCommand               | 复制已序列化的属性。                                                                                               |
| FindPropertyRelative           | 从当前属性的相关路径检索 SerializedProperty。                                                                      |
| `GetArrayElementAtIndex`       | 返回数组中指定索引处的元素。                                                                                       |
| GetEndProperty                 | 检索定义此属性起始范围的 SerializedProperty。                                                                      |
| GetEnumerator                  | 检索用于枚举当前属性的可见子属性的迭代器。如果该属性是数组，则它将枚举数组元素。                                   |
| `GetFixedBufferElementAtIndex` | 返回固定缓冲区中指定索引处的元素。                                                                                 |
| `InsertArrayElementAtIndex`    | 在数组中的指定索引处插入空元素。                                                                                   |
| MoveArrayElement               | 将数组元素从 srcIndex 移到 dstIndex。                                                                              |
| Next                           | 移至下一个属性。                                                                                                   |
| NextVisible                    | 移至下一个可见属性。                                                                                               |
| Reset                          | 移至对象的第一个属性。                                                                                             |

##### 静态函数

| **函数**      | **描述**                                                                     |
| ------------- | ---------------------------------------------------------------------------- |
| DataEquals    | 比较两个 SerializedProperties 的数据。此方法会忽略路径和 SerializedObjects。 |
| EqualContents | 查看包含的序列化属性是否相等。                                               |


##### 实现字典序列化

此处仅考虑一种字典情况

Mono脚本需要继承`ISerializationCallbackReceiver`接口

    public Dictionary<int, string> serDic = new Dictionary<int, string>() { { 1,"张三"},{ 2,"李四"} };//被序列化字典
    [SerializeField] private List<int> keyList = new List<int>();//序列化数据的临时容器
    [SerializeField] private List<string> valueList = new List<string>();
    
    public void OnAfterDeserialize()
    {//反序列化前将临时数据装入字典
        serDic.Clear();
        for (int i = 0; i < keyList.Count; i++)
        {
            if (!serDic.ContainsKey(keyList[i]))
                serDic.Add(keyList[i],valueList[i]);
            else
                Debug.LogWarning("已有此键："+keyList[i]);
        }
    }
    
    public void OnBeforeSerialize()
    {//系列化前将字典数据放入临时容器
        keyList.Clear();
        valueList.Clear();
        foreach (var item in serDic)
        {
            keyList.Add(item.Key);
            valueList.Add(item.Value);
        }
    }

Editor脚本

    private int dicCount;
    private SerializedProperty dicKeys;
    private SerializedProperty dicValues;
    
    private void OnEnable()
    {
        //初始化，找到双方属性做关联
        dicKeys = serializedObject.FindProperty("keyList");
        dicValues = serializedObject.FindProperty("valueList");
        dicCount = dicKeys.arraySize;
    }
    
    public override void OnInspectorGUI()
    {
        dicCount = EditorGUILayout.IntField("字典数量", dicCount);
    
        for (int i = dicKeys.arraySize-1; i >=dicCount; i--)
        {//删除多余键值对
            dicKeys.DeleteArrayElementAtIndex(i);
            dicValues.DeleteArrayElementAtIndex(i);
        }
    
        for (int i = 0; i < dicCount; i++)
        {//扩容
            if (dicKeys.arraySize<=i)
            {
                dicKeys.InsertArrayElementAtIndex(i);
                dicValues.InsertArrayElementAtIndex(i);
            }
    
            SerializedProperty indexKey = dicKeys.GetArrayElementAtIndex(i);
            SerializedProperty indexValue = dicValues.GetArrayElementAtIndex(i);
            EditorGUILayout.BeginHorizontal();
            indexKey.intValue = EditorGUILayout.IntField("学号：", indexKey.intValue);
            indexValue.stringValue = EditorGUILayout.TextField("姓名：", indexValue.stringValue);
            EditorGUILayout.EndHorizontal();


        }
        //应用数据
        serializedObject.ApplyModifiedProperties();
    
    }
此处扩容出来的键值对是继承了上一个键值对的数据，会触发字典重复的bug，实际使用时可以考虑对扩容键值对的数据初始化     




### **Scene窗口拓展**

- **Handles公共类**
[Handles官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/Handles.html)         
 using UnityEditor;
`Handles.Button`需要传入的`capFunc`此处并未记录，因为Button不常用，故不记录，如果需要查看官方文档。       
`OnSceneGUI`绘制的前提是，选中该物体    


| 方法/属性                   | 说明                                                                    | 示例                                                        | 图例                                                                                                           |
| --------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| Handles.color               | 设置句柄的颜色。                                                        | Handles.color = Color.red                                   |                                                                                                                |
| Handles.Label               | 在场景视图中指定位置绘制文本标签。                                      | Handles.Label(position, "Label Text")                       | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/label.png)               |
| Handles.Button              | 在场景视图中绘制一个可点击的按钮句柄。不同的`capFunc`呈现不同的点击样式 | Handles.Button(position, rotation, size, pickSize, capFunc) |                                                                                                                |
| Handles.DrawLine            | 在场景视图中绘制一条线。                                                | Handles.DrawLine(startPosition, endPosition)                | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawLine.png)            |
| Handles.DrawDottedLine      | 在场景视图中绘制一条虚线。                                              | Handles.DrawDottedLine(startPosition, endPosition)          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawDottedLine.png)      |
| Handles.DrawWireArc         | 在场景视图中绘制一条弧线。                                              | Handles.DrawWireArc(center,normal,from,angle,radius)        | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawWireArc.png)         |
| Handles.DrawSolidArc        | 在场景视图中绘制一个扇形。                                              | Handles.DrawSolidArc(center,normal,from,angle,radius)       | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawSolidArc.png)        |
| Handles.DrawSolidDisc       | 绘制一个实心圆盘。                                                      | Handles.DrawSolidDisc(position, normal, radius)             | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawSolidDisc.png)       |
| Handles.DrawWireDisc        | 绘制一个线框圆盘。                                                      | Handles.DrawWireDisc(position, normal, radius)              | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawWireDisc.png)        |
| Handles.DrawWireCube        | 在场景视图中绘制一个矩形。                                              | Handles.DrawWireCube(center, size)                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawWireCube.png)        |
| Handles.DrawAAConvexPolygon | 绘制一个poly面                                                          | Handles.DrawAAConvexPolygon(points)                         | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawAAConvexPolygon.png) |
| Handles.DrawPolyLine        | 在场景视图中绘制一条poly线，可以多个中转点。                            | Handles.DrawDottedLine(startPosition, endPosition)          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawPolyLine.png)        |
| Handles.PositionHandle      | 绘制一个可拖动的三维位置句柄。                                          | obj=Handles.PositionHandle(position, rotation)              | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/PositionHandle.png)      |
| Handles.ScaleHandle         | 绘制一个可拖动的三维缩放句柄。                                          | Handles.ScaleHandle(scale, position, rotation, size)        | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/ScaleHandle.png)         |
| Handles.RotationHandle      | 绘制一个可拖动的三维旋转句柄。                                          | Handles.RotationHandle(rotation, position)                  | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/RotationHandle.png)      |
| Handles.FreeMoveHandle      | 绘制一个可以自由移动的句柄。重载可以加入`snap`作为Ctrl时的固定移动距离  | Handles.FreeMoveHandle(position, rotation, size)            | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/FreeMoveHandle.png)      |
| Handles.FreeRotationHandle  | 绘制一个可以自由移动的句柄。                                            | Handles.FreeRotateHandle(rotation,position, size)           | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/FreeRotateHandle.png)    |
| Handles.BeginGUI            | 开始绘制GUI。                                                           | BeginGUI和EndGUI包裹着GUI逻辑，实现在Scene绘制GUi           | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/handles/DrawGUI.png)             |
| Handles.EndGUI              | GUI绘制结束。                                                           |                                                             |                                                                                                                |




代码示例：      

	[CustomEditor(typeof(TargetMono))]
	public class Handles: Editor
	{
		private TargetMono obj;
	
		private void OnEnable()
	    { obj = target as TargetMono;}
		
		private void OnSceneGUI() {
	    //Logic
		}
	}



- **HandleUtility公共类**
[HandleUtility官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/HandleUtility.html)       
using UnityEditor;      

| 方法/属性                              | 说明                                                           | 示例                                                                                 |
| -------------------------------------- | -------------------------------------------------------------- | ------------------------------------------------------------------------------------ |
| `HandleUtility.GUIPointToWorldRay`     | 将 GUI 点转换为射线（屏幕坐标转换为世界坐标射线）。            | Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);             |
| `HandleUtility.WorldToGUIPoint`        | 将世界坐标转换为 GUI 坐标。                                    | Vector2 guiPoint = HandleUtility.WorldToGUIPoint(worldPosition);                     |
| HandleUtility.WorldToGUIPointWithDepth | 将世界坐标转换为 GUI 坐标，并返回深度信息。                    | Vector3 guiPointWithDepth = HandleUtility.WorldToGUIPointWithDepth(worldPosition);   |
| `HandleUtility.GetHandleSize`          | 获取与场景视图中给定位置相关的缩放因子，用于动态调整句柄大小。 | float handleSize = HandleUtility.GetHandleSize(position);                            |
| `HandleUtility.PickGameObject`         | 在鼠标点击的地方拾取游戏对象。                                 | GameObject pickedObj = HandleUtility.PickGameObject(mousePosition, ignoreSelection); |
| HandleUtility.PickRectObjects          | 在给定的矩形区域内拾取所有对象。                               | GameObject[] pickedObjs = HandleUtility.PickRectObjects(rect, allowSceneObjects);    |
| HandleUtility.AddDefaultControl        | 将指定的控件 ID 设置为默认控件，避免 UI 控件接收输入。         | HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));         |
| HandleUtility.NearestControl           | 获取当前最近的控件 ID，用于处理交互逻辑。                      | int nearestID = HandleUtility.nearestControl;                                        |
| HandleUtility.DistanceToLine           | 计算鼠标位置与线段之间的距离，用于检测交互。                   | float distance = HandleUtility.DistanceToLine(p1, p2);                               |
| `HandleUtility.DistanceToCircle`       | 计算鼠标位置与圆之间的距离。                                   | float distance = HandleUtility.DistanceToCircle(center, radius);                     |
| HandleUtility.IgnoreRaySnapObjects     | 设置一个数组，包含应忽略射线捕捉的对象。                       | HandleUtility.ignoreRaySnapObjects = new GameObject[] { obj };                       |
| HandleUtility.PlaceObject              | 根据射线放置对象，返回放置点的位置。                           | Vector3 position = HandleUtility.PlaceObject(ray, out normal);                       |
| HandleUtility.Repaint                  | 立即重绘当前视图。                                             | HandleUtility.Repaint();                                                             |

- **Gizmos公共类**
[Gizmos官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/Gizmos.html)           
using UnityEngine;      
主要功能为绘制辅助图形。        
`OnDrawGizmosSelected`为仅选中时执行，`OnDrawGizmos`不需要选中也会执行      


| 方法/属性             | 说明                                         | 示例                                                                                                                                  | 图例                                                                                                     |
| --------------------- | -------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| Gizmos.color          | 设置或获取 Gizmos 绘制的颜色。               | Gizmos.color = Color.red;                                                                                                             |                                                                                                          |
| Gizmos.matrix         | 设置或获取 Gizmos 使用的变换矩阵。           | Gizmos.matrix = transform.localToWorldMatrix; 或者Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one); |                                                                                                          |
| Gizmos.DrawLine       | 绘制一条从起点到终点的线段。                 | Gizmos.DrawLine(Vector3.zero, new Vector3(1, 1, 1));                                                                                  | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawLine.png)       |
| Gizmos.DrawRay        | 绘制一条从起点出发的射线。                   | Gizmos.DrawRay(Vector3.zero, Vector3.forward * 5);                                                                                    | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawRay.png)        |
| Gizmos.DrawWireCube   | 绘制一个以指定位置为中心的线框立方体。       | Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, 1, 1));                                                                              | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawWireCube.png)   |
| Gizmos.DrawCube       | 绘制一个以指定位置为中心的实心立方体。       | Gizmos.DrawCube(Vector3.zero, new Vector3(1, 1, 1));                                                                                  | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawCube.png)       |
| Gizmos.DrawWireSphere | 绘制一个以指定位置为中心的线框球体。         | Gizmos.DrawWireSphere(Vector3.zero, 1.0f);                                                                                            | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawWireSphere.png) |
| Gizmos.DrawSphere     | 绘制一个以指定位置为中心的实心球体。         | Gizmos.DrawSphere(Vector3.zero, 1.0f);                                                                                                | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawSphere.png)     |
| Gizmos.DrawFrustum    | 绘制一个视锥体，模拟摄像机的视角范围。       | Gizmos.DrawFrustum(Vector3.zero, 60, 5, 1, 1.33f);                                                                                    | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawFrustum.png)    |
| Gizmos.DrawMesh       | 绘制一个实心网格。                           | Gizmos.DrawMesh(mesh, position);                                                                                                      | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawMesh.png)       |
| Gizmos.DrawWireMesh   | 绘制一个线框网格。                           | Gizmos.DrawWireMesh(mesh, position);                                                                                                  | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawWireMesh.png)   |
| Gizmos.DrawIcon       | 在场景视图中绘制一个图标，通常用于标记位置。 | Gizmos.DrawIcon(Vector3.zero, "MyIcon");                                                                                              | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawIcon.png)       |
| Gizmos.DrawGUITexture | 在屏幕上绘制 2D 纹理。不常用                 | Gizmos.DrawGUITexture(new Rect(0, 0, 100, 100), texture);                                                                             | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/gizmos/DrawGUITexture.png) |




### **EditorUtility公共类**
[EditorUtility官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/EditorUtility.html)           
**当前仅为唐老师教授内容，EditorUtility还有很多内容需要后续自行了解**
| 方法                   | 描述                                                               | 代码示例                                                                                              | 图例                                                                                                                  |
| ---------------------- | ------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| DisplayDialog          | 此方法显示模态对话框。                                             | EditorUtility.DisplayDialog("确认窗口","确定吗？","确定")                                             | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/editorUtility/DisplayDialog.png)        |
| DisplayDialogComplex   | 显示含有三个按钮的模态对话框。                                     | int result = EditorUtility.DisplayDialogComplex("三键提示", "显示信息", "选项1", "关闭", "选项2");    | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/editorUtility/DisplayDialogComplex.png) |
| DisplayProgressBar     | 显示或更新进度条。                                                 | EditorUtility.DisplayProgressBar("进度条标题", "进度条窗口显示内容", value);                          | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/editorUtility/DisplayProgressBar.png)   |
| ClearProgressBar       | 关闭进度条                                                         | EditorUtility.ClearProgressBar();                                                                     |                                                                                                                       |
| SaveFilePanel          | 显示“保存文件”对话框并返回所选的路径名称。                         | string str = EditorUtility.SaveFilePanel("保存我的文件", Application.dataPath, "Test", "txt");        | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/editorUtility/SaveFilePanel.png)        |
| SaveFilePanelInProject | 在项目的 Assets 文件夹中显示“保存文件”对话框并返回所选的路径名称。 | string str2 = EditorUtility.SaveFilePanelInProject("保存项目内的文件", "Test2", "png", "自定义文件"); |                                                                                                                       |
| SaveFolderPanel        | 显示“保存文件夹”对话框并返回所选的路径名称。                       | string str3 = EditorUtility.SaveFolderPanel("得到一个存储路径（文件夹）", Application.dataPath, "");  |                                                                                                                       |
| OpenFilePanel          | 显示“打开文件”对话框并返回所选的路径名称。                         | string str4 = EditorUtility.OpenFilePanel("得到一个文件路径", Application.dataPath, "txt");           | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/editorUtility/OpenFilePanel.png)        |
| OpenFolderPanel        | 显示“打开文件夹”对话框并返回所选的路径名称。                       | string str4 = EditorUtility.OpenFolderPanel("得到一个文件路径", Application.dataPath, "");            |                                                                                                                       |
| CollectDependencies    | 计算并返回 roots 中列出的资源所依赖的所有资源的列表。              | Object[] objs = EditorUtility.CollectDependencies(new Object[] { objTest1 });                         | ![Image](https://github.com/GavinZ233/Learning-EditorExtend/raw/dev/Other/Img/editorUtility/CollectDependencies.png)  |




### **AssetDatabase公共类**
[AssetDatabase官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/AssetDatabase.html)           
**当前仅为唐老师教授内容，还有很多方法需要后续自行了解**      
`自身经验：当批量处理文件时，可尝试获取文件的GUID，再通过GUID做处理，相对于获取路径更加灵活`         

AssetDatabase方法操作的资源都处于`Assets`文件夹下，属于Unity资源路径，超出此范围的操作需要使用`File`即C#的资源操作      

| 方法                       | 描述                                                                                                                           | 代码示例                                                                         |
| -------------------------- | ------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------- |
| CreateAsset                | 创建资源                                                                                                                       | AssetDatabase.CreateAsset(mat, "Assets/Resources/MyMaterial.mat");               |
| CreateFolder               | 创建文件夹                                                                                                                     | AssetDatabase.CreateFolder("Assets/Resources", "MyTestFolder");                  |
| CopyAsset                  | 拷贝资源                                                                                                                       | AssetDatabase.CopyAsset("Assets/FromFolder/pdf.png", "Assets/ToFolder/pdf.png"); |
| MoveAsset                  | 移动资源                                                                                                                       | AssetDatabase.MoveAsset("Assets/FromFolder/pdf.png", "Assets/ToFolder/pdf.png"); |
| DeleteAsset                | 删除资源                                                                                                                       | AssetDatabase.DeleteAsset("Assets/Resources/pdf.png");                           |
| DeleteAssets               | 批量删除资源，失败的路径会记录到outFailedPaths中                                                                               | AssetDatabase.DeleteAssets(paths, outFailedPaths);                               |
| GetAssetPath               | 获取资源路径                                                                                                                   | AssetDatabase.GetAssetPath(Selection.activeObject)                               |
| LoadAssetAtPath            | 根据路径加载资源                                                                                                               | AssetDatabase.LoadAllAssetsAtPath(assetPath);                                    |
| LoadAllAssetsAtPath        | 根据路径加载所有资源,一般可以用来加载图集资源，返回值为Object数据。 如果是图集，第一个为图集本身，之后的便是图集中的所有Sprite | AssetDatabase.Refresh();                                                         |
| Refresh                    | 刷新，当对资源进行移动、导入、删除等操作后，需要执行刷新                                                                       | AssetDatabase.Refresh();                                                         |
| GetImplicitAssetBundleName | 返回该路径资源所属的AB包名                                                                                                     | GetImplicitAssetBundleName(assetPath);                                           |




### **PrefabUtility公共类**
[PrefabUtility官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/PrefabUtility.html)           
**当前仅为唐老师教授内容，还有很多方法需要后续自行了解**      



| 方法                 | 描述                                                                                                     | 代码示例                                                         |
| -------------------- | -------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- |
| SaveAsPrefabAsset    | 在给定路径上，从给定的游戏对象创建一个预制件资源                                                         | PrefabUtility.SaveAsPrefabAsset(obj, savePath);                  |
| LoadPrefabContents   | （获得一个预制体实例化的GameObject）将给定路径上的预制件资源加载到孤立场景中，并返回预制件的根游戏对象。 | GameObject testObj = PrefabUtility.LoadPrefabContents(loadPath); |
| UnloadPrefabContents | 从内存中释放以前随 LoadPrefabContents 加载的预制件的内容。                                               | PrefabUtility.UnloadPrefabContents(testObj);                     |
| SavePrefabAsset      | （针对预制体资源）使用此函数将内存中存在的现有预制件资源版本保存回磁盘。                                 | PrefabUtility.SavePrefabAsset(testObj);                          |
| InstantiatePrefab    | 将给定场景中的给定预制件实例化。                                                                         | PrefabUtility.InstantiatePrefab(testObj);                        |


`LoadPrefabContents`此方法方便代码修改预制体，此时是实例化的，需要SaveAsPrefabAsset才能保存。



### **EditorApplication公共类**
[EditorApplication官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/EditorApplication.html)           


| 方法/属性                                 | 描述                                             | 示例代码                                                     |
| ----------------------------------------- | ------------------------------------------------ | ------------------------------------------------------------ |
| EditorApplication.update                  | 每帧更新事件，可以用于在编辑器中执行一些逻辑。   | EditorApplication.update += MyUpdateFunction;                |
| EditorApplication.hierarchyChanged        | 层级视图变化事件，当场景中的对象发生变化时触发。 | EditorApplication.hierarchyChanged += OnHierarchyChanged;    |
| EditorApplication.projectChanged          | 项目变化事件，当项目中的资源发生变化时触发。     | EditorApplication.projectChanged += OnProjectChanged;        |
| EditorApplication.playModeStateChanged    | 编辑器播放状态变化时触发。                       | EditorApplication.playModeStateChanged += OnPlayModeChanged; |
| EditorApplication.pauseStateChanged       | 编辑器暂停状态变化时触发。                       | EditorApplication.pauseStateChanged += OnPauseStateChanged;  |
| EditorApplication.isPlaying               | 判断当前是否处于游戏运行状态。                   | bool isPlaying = EditorApplication.isPlaying;                |
| EditorApplication.isPaused                | 判断当前游戏是否处于暂停状态。                   | bool isPaused = EditorApplication.isPaused;                  |
| EditorApplication.isCompiling             | 判断Unity编辑器是否正在编译代码。                | bool isCompiling = EditorApplication.isCompiling;            |
| EditorApplication.isUpdating              | 判断Unity编辑器是否正在刷新AssetDatabase。       | bool isUpdating = EditorApplication.isUpdating;              |
| EditorApplication.applicationContentsPath | 获取Unity安装目录Data路径。                      | string path = EditorApplication.applicationContentsPath;     |
| EditorApplication.applicationPath         | 获取Unity安装目录可执行程序路径。                | string path = EditorApplication.applicationPath;             |
| EditorApplication.Exit(0)                 | 退出Unity编辑器。                                | EditorApplication.Exit(0);                                   |
| EditorApplication.ExitPlaymode()          | 退出播放模式，切换到编辑模式。                   | EditorApplication.ExitPlaymode();                            |
| EditorApplication.EnterPlaymode()         | 进入播放模式。                                   | EditorApplication.EnterPlaymode();                           |


 ### **EditorSceneManager公共类**
[EditorSceneManager官方文档](https://docs.unity.cn/cn/2021.3/ScriptReference/SceneManagement.EditorSceneManager.html)           


| 方法/属性                           | 描述                           | 示例代码                                                        |
| ----------------------------------- | ------------------------------ | --------------------------------------------------------------- |
| EditorSceneManager.NewScene()       | 创建一个新的场景。             | EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);  |
| EditorSceneManager.OpenScene()      | 打开一个现有场景。             | EditorSceneManager.OpenScene("Assets/Scenes/MyScene.unity");    |
| EditorSceneManager.SaveScene()      | 保存当前场景。                 | EditorSceneManager.SaveScene(SceneManager.GetActiveScene());    |
| EditorSceneManager.SaveSceneAs()    | 另存为新的场景。               | EditorSceneManager.SaveSceneAs("Assets/Scenes/NewScene.unity"); |
| EditorSceneManager.GetActiveScene() | 获取当前活动场景。             | Scene currentScene = EditorSceneManager.GetActiveScene();       |
| EditorSceneManager.SetActiveScene() | 设置当前活动场景。             | EditorSceneManager.SetActiveScene(scene);                       |
| EditorSceneManager.sceneCount       | 获取当前已加载场景的数量。     | int sceneCount = EditorSceneManager.sceneCount;                 |
| EditorSceneManager.GetSceneAt()     | 获取指定索引的已加载场景。     | Scene scene = EditorSceneManager.GetSceneAt(0);                 |
| EditorSceneManager.sceneOpened      | 当一个场景被打开时触发的事件。 | EditorSceneManager.sceneOpened += OnSceneOpened;                |
| EditorSceneManager.sceneSaved       | 当一个场景被保存时触发的事件。 | EditorSceneManager.sceneSaved += OnSceneSaved;                  |
| EditorSceneManager.sceneClosing     | 当一个场景关闭时触发的事件。   | EditorSceneManager.sceneClosing += OnSceneClosing;              |
| EditorSceneManager.sceneUnloaded    | 当一个场景卸载时触发的事件。   | EditorSceneManager.sceneUnloaded += OnSceneUnloaded;            |
| EditorSceneManager.LoadScene()      | 加载一个场景（在编辑器中）。   | EditorSceneManager.LoadScene("SceneName");                      |
| EditorSceneManager.MergeScenes()    | 将一个场景合并到另一个场景中。 | EditorSceneManager.MergeScenes(sceneToMerge, targetScene);      |





### **CompilationPipeline公共类**


### **AssetImporter和AssetPostprocessor**



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

