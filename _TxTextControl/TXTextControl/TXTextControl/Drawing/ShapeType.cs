namespace TXTextControl.Drawing
{
	/// <summary>Determines the type a shape can have.</summary>
	public enum ShapeType
	{
		/// <summary>Line Shape. When the item is serialized out as xml, its value is "line".</summary>
		Line = 1,
		/// <summary>Line Inverse Shape. When the item is serialized out as xml, its value is "lineInv".</summary>
		LineInverse,
		/// <summary>Triangle Shape. When the item is serialized out as xml, its value is "triangle".</summary>
		Triangle,
		/// <summary>Right Triangle Shape. When the item is serialized out as xml, its value is "rtTriangle".</summary>
		RightTriangle,
		/// <summary>Rectangle Shape. When the item is serialized out as xml, its value is "rect".</summary>
		Rectangle,
		/// <summary>Diamond Shape. When the item is serialized out as xml, its value is "diamond".</summary>
		Diamond,
		/// <summary>Parallelogram Shape. When the item is serialized out as xml, its value is "parallelogram".</summary>
		Parallelogram,
		/// <summary>Trapezoid Shape. When the item is serialized out as xml, its value is "trapezoid".</summary>
		Trapezoid,
		/// <summary>Non-Isosceles Trapezoid Shape. When the item is serialized out as xml, its value is "nonIsoscelesTrapezoid".</summary>
		NonIsoscelesTrapezoid,
		/// <summary>Pentagon Shape. When the item is serialized out as xml, its value is "pentagon".</summary>
		Pentagon,
		/// <summary>Hexagon Shape. When the item is serialized out as xml, its value is "hexagon".</summary>
		Hexagon,
		/// <summary>Heptagon Shape. When the item is serialized out as xml, its value is "heptagon".</summary>
		Heptagon,
		/// <summary>Octagon Shape. When the item is serialized out as xml, its value is "octagon".</summary>
		Octagon,
		/// <summary>Decagon Shape. When the item is serialized out as xml, its value is "decagon".</summary>
		Decagon,
		/// <summary>Dodecagon Shape. When the item is serialized out as xml, its value is "dodecagon".</summary>
		Dodecagon,
		/// <summary>Four Pointed Star Shape. When the item is serialized out as xml, its value is "star4".</summary>
		Star4,
		/// <summary>Five Pointed Star Shape. When the item is serialized out as xml, its value is "star5".</summary>
		Star5,
		/// <summary>Six Pointed Star Shape. When the item is serialized out as xml, its value is "star6".</summary>
		Star6,
		/// <summary>Seven Pointed Star Shape. When the item is serialized out as xml, its value is "star7".</summary>
		Star7,
		/// <summary>Eight Pointed Star Shape. When the item is serialized out as xml, its value is "star8".</summary>
		Star8,
		/// <summary>Ten Pointed Star Shape. When the item is serialized out as xml, its value is "star10".</summary>
		Star10,
		/// <summary>Twelve Pointed Star Shape. When the item is serialized out as xml, its value is "star12".</summary>
		Star12,
		/// <summary>Sixteen Pointed Star Shape. When the item is serialized out as xml, its value is "star16".</summary>
		Star16,
		/// <summary>Twenty Four Pointed Star Shape. When the item is serialized out as xml, its value is "star24".</summary>
		Star24,
		/// <summary>Thirty Two Pointed Star Shape. When the item is serialized out as xml, its value is "star32".</summary>
		Star32,
		/// <summary>Round Corner Rectangle Shape. When the item is serialized out as xml, its value is "roundRect".</summary>
		RoundRectangle,
		/// <summary>One Round Corner Rectangle Shape. When the item is serialized out as xml, its value is "round1Rect".</summary>
		Round1Rectangle,
		/// <summary>Two Same-side Round Corner Rectangle Shape. When the item is serialized out as xml, its value is "round2SameRect".</summary>
		Round2SameRectangle,
		/// <summary>Two Diagonal Round Corner Rectangle Shape. When the item is serialized out as xml, its value is "round2DiagRect".</summary>
		Round2DiagonalRectangle,
		/// <summary>One Snip One Round Corner Rectangle Shape. When the item is serialized out as xml, its value is "snipRoundRect".</summary>
		SnipRoundRectangle,
		/// <summary>One Snip Corner Rectangle Shape. When the item is serialized out as xml, its value is "snip1Rect".</summary>
		Snip1Rectangle,
		/// <summary>Two Same-side Snip Corner Rectangle Shape. When the item is serialized out as xml, its value is "snip2SameRect".</summary>
		Snip2SameRectangle,
		/// <summary>Two Diagonal Snip Corner Rectangle Shape. When the item is serialized out as xml, its value is "snip2DiagRect".</summary>
		Snip2DiagonalRectangle,
		/// <summary>Plaque Shape. When the item is serialized out as xml, its value is "plaque".</summary>
		Plaque,
		/// <summary>Ellipse Shape. When the item is serialized out as xml, its value is "ellipse".</summary>
		Ellipse,
		/// <summary>Teardrop Shape. When the item is serialized out as xml, its value is "teardrop".</summary>
		Teardrop,
		/// <summary>Home Plate Shape. When the item is serialized out as xml, its value is "homePlate".</summary>
		HomePlate,
		/// <summary>Chevron Shape. When the item is serialized out as xml, its value is "chevron".</summary>
		Chevron,
		/// <summary>Pie Wedge Shape. When the item is serialized out as xml, its value is "pieWedge".</summary>
		PieWedge,
		/// <summary>Pie Shape. When the item is serialized out as xml, its value is "pie".</summary>
		Pie,
		/// <summary>Block Arc Shape. When the item is serialized out as xml, its value is "blockArc".</summary>
		BlockArc,
		/// <summary>Donut Shape. When the item is serialized out as xml, its value is "donut".</summary>
		Donut,
		/// <summary>No Smoking Shape. When the item is serialized out as xml, its value is "noSmoking".</summary>
		NoSmoking,
		/// <summary>Right Arrow Shape. When the item is serialized out as xml, its value is "rightArrow".</summary>
		RightArrow,
		/// <summary>Left Arrow Shape. When the item is serialized out as xml, its value is "leftArrow".</summary>
		LeftArrow,
		/// <summary>Up Arrow Shape. When the item is serialized out as xml, its value is "upArrow".</summary>
		UpArrow,
		/// <summary>Down Arrow Shape. When the item is serialized out as xml, its value is "downArrow".</summary>
		DownArrow,
		/// <summary>Striped Right Arrow Shape. When the item is serialized out as xml, its value is "stripedRightArrow".</summary>
		StripedRightArrow,
		/// <summary>Notched Right Arrow Shape. When the item is serialized out as xml, its value is "notchedRightArrow".</summary>
		NotchedRightArrow,
		/// <summary>Bent Up Arrow Shape. When the item is serialized out as xml, its value is "bentUpArrow".</summary>
		BentUpArrow,
		/// <summary>Left Right Arrow Shape. When the item is serialized out as xml, its value is "leftRightArrow".</summary>
		LeftRightArrow,
		/// <summary>Up Down Arrow Shape. When the item is serialized out as xml, its value is "upDownArrow".</summary>
		UpDownArrow,
		/// <summary>Left Up Arrow Shape. When the item is serialized out as xml, its value is "leftUpArrow".</summary>
		LeftUpArrow,
		/// <summary>Left Right Up Arrow Shape. When the item is serialized out as xml, its value is "leftRightUpArrow".</summary>
		LeftRightUpArrow,
		/// <summary>Quad-Arrow Shape. When the item is serialized out as xml, its value is "quadArrow".</summary>
		QuadArrow,
		/// <summary>Callout Left Arrow Shape. When the item is serialized out as xml, its value is "leftArrowCallout".</summary>
		LeftArrowCallout,
		/// <summary>Callout Right Arrow Shape. When the item is serialized out as xml, its value is "rightArrowCallout".</summary>
		RightArrowCallout,
		/// <summary>Callout Up Arrow Shape. When the item is serialized out as xml, its value is "upArrowCallout".</summary>
		UpArrowCallout,
		/// <summary>Callout Down Arrow Shape. When the item is serialized out as xml, its value is "downArrowCallout".</summary>
		DownArrowCallout,
		/// <summary>Callout Left Right Arrow Shape. When the item is serialized out as xml, its value is "leftRightArrowCallout".</summary>
		LeftRightArrowCallout,
		/// <summary>Callout Up Down Arrow Shape. When the item is serialized out as xml, its value is "upDownArrowCallout".</summary>
		UpDownArrowCallout,
		/// <summary>Callout Quad-Arrow Shape. When the item is serialized out as xml, its value is "quadArrowCallout".</summary>
		QuadArrowCallout,
		/// <summary>Bent Arrow Shape. When the item is serialized out as xml, its value is "bentArrow".</summary>
		BentArrow,
		/// <summary>U-Turn Arrow Shape. When the item is serialized out as xml, its value is "uturnArrow".</summary>
		UTurnArrow,
		/// <summary>Circular Arrow Shape. When the item is serialized out as xml, its value is "circularArrow".</summary>
		CircularArrow,
		/// <summary>Left Circular Arrow Shape. When the item is serialized out as xml, its value is "leftCircularArrow".</summary>
		LeftCircularArrow,
		/// <summary>Left Right Circular Arrow Shape. When the item is serialized out as xml, its value is "leftRightCircularArrow".</summary>
		LeftRightCircularArrow,
		/// <summary>Curved Right Arrow Shape. When the item is serialized out as xml, its value is "curvedRightArrow".</summary>
		CurvedRightArrow,
		/// <summary>Curved Left Arrow Shape. When the item is serialized out as xml, its value is "curvedLeftArrow".</summary>
		CurvedLeftArrow,
		/// <summary>Curved Up Arrow Shape. When the item is serialized out as xml, its value is "curvedUpArrow".</summary>
		CurvedUpArrow,
		/// <summary>Curved Down Arrow Shape. When the item is serialized out as xml, its value is "curvedDownArrow".</summary>
		CurvedDownArrow,
		/// <summary>Swoosh Arrow Shape. When the item is serialized out as xml, its value is "swooshArrow".</summary>
		SwooshArrow,
		/// <summary>Cube Shape. When the item is serialized out as xml, its value is "cube".</summary>
		Cube,
		/// <summary>Can Shape. When the item is serialized out as xml, its value is "can".</summary>
		Can,
		/// <summary>Lightning Bolt Shape. When the item is serialized out as xml, its value is "lightningBolt".</summary>
		LightningBolt,
		/// <summary>Heart Shape. When the item is serialized out as xml, its value is "heart".</summary>
		Heart,
		/// <summary>Sun Shape. When the item is serialized out as xml, its value is "sun".</summary>
		Sun,
		/// <summary>Moon Shape. When the item is serialized out as xml, its value is "moon".</summary>
		Moon,
		/// <summary>Smiley Face Shape. When the item is serialized out as xml, its value is "smileyFace".</summary>
		SmileyFace,
		/// <summary>Irregular Seal 1 Shape. When the item is serialized out as xml, its value is "irregularSeal1".</summary>
		IrregularSeal1,
		/// <summary>Irregular Seal 2 Shape. When the item is serialized out as xml, its value is "irregularSeal2".</summary>
		IrregularSeal2,
		/// <summary>Folded Corner Shape. When the item is serialized out as xml, its value is "foldedCorner".</summary>
		FoldedCorner,
		/// <summary>Bevel Shape. When the item is serialized out as xml, its value is "bevel".</summary>
		Bevel,
		/// <summary>Frame Shape. When the item is serialized out as xml, its value is "frame".</summary>
		Frame,
		/// <summary>Half Frame Shape. When the item is serialized out as xml, its value is "halfFrame".</summary>
		HalfFrame,
		/// <summary>Corner Shape. When the item is serialized out as xml, its value is "corner".</summary>
		Corner,
		/// <summary>Diagonal Stripe Shape. When the item is serialized out as xml, its value is "diagStripe".</summary>
		DiagonalStripe,
		/// <summary>Chord Shape. When the item is serialized out as xml, its value is "chord".</summary>
		Chord,
		/// <summary>Curved Arc Shape. When the item is serialized out as xml, its value is "arc".</summary>
		Arc,
		/// <summary>Left Bracket Shape. When the item is serialized out as xml, its value is "leftBracket".</summary>
		LeftBracket,
		/// <summary>Right Bracket Shape. When the item is serialized out as xml, its value is "rightBracket".</summary>
		RightBracket,
		/// <summary>Left Brace Shape. When the item is serialized out as xml, its value is "leftBrace".</summary>
		LeftBrace,
		/// <summary>Right Brace Shape. When the item is serialized out as xml, its value is "rightBrace".</summary>
		RightBrace,
		/// <summary>Bracket Pair Shape. When the item is serialized out as xml, its value is "bracketPair".</summary>
		BracketPair,
		/// <summary>Brace Pair Shape. When the item is serialized out as xml, its value is "bracePair".</summary>
		BracePair,
		/// <summary>Straight Connector 1 Shape. When the item is serialized out as xml, its value is "straightConnector1".</summary>
		StraightConnector1,
		/// <summary>Bent Connector 2 Shape. When the item is serialized out as xml, its value is "bentConnector2".</summary>
		BentConnector2,
		/// <summary>Bent Connector 3 Shape. When the item is serialized out as xml, its value is "bentConnector3".</summary>
		BentConnector3,
		/// <summary>Bent Connector 4 Shape. When the item is serialized out as xml, its value is "bentConnector4".</summary>
		BentConnector4,
		/// <summary>Bent Connector 5 Shape. When the item is serialized out as xml, its value is "bentConnector5".</summary>
		BentConnector5,
		/// <summary>Curved Connector 2 Shape. When the item is serialized out as xml, its value is "curvedConnector2".</summary>
		CurvedConnector2,
		/// <summary>Curved Connector 3 Shape. When the item is serialized out as xml, its value is "curvedConnector3".</summary>
		CurvedConnector3,
		/// <summary>Curved Connector 4 Shape. When the item is serialized out as xml, its value is "curvedConnector4".</summary>
		CurvedConnector4,
		/// <summary>Curved Connector 5 Shape. When the item is serialized out as xml, its value is "curvedConnector5".</summary>
		CurvedConnector5,
		/// <summary>Callout 1 Shape. When the item is serialized out as xml, its value is "callout1".</summary>
		Callout1,
		/// <summary>Callout 2 Shape. When the item is serialized out as xml, its value is "callout2".</summary>
		Callout2,
		/// <summary>Callout 3 Shape. When the item is serialized out as xml, its value is "callout3".</summary>
		Callout3,
		/// <summary>Callout 1 Shape. When the item is serialized out as xml, its value is "accentCallout1".</summary>
		AccentCallout1,
		/// <summary>Callout 2 Shape. When the item is serialized out as xml, its value is "accentCallout2".</summary>
		AccentCallout2,
		/// <summary>Callout 3 Shape. When the item is serialized out as xml, its value is "accentCallout3".</summary>
		AccentCallout3,
		/// <summary>Callout 1 with Border Shape. When the item is serialized out as xml, its value is "borderCallout1".</summary>
		BorderCallout1,
		/// <summary>Callout 2 with Border Shape. When the item is serialized out as xml, its value is "borderCallout2".</summary>
		BorderCallout2,
		/// <summary>Callout 3 with Border Shape. When the item is serialized out as xml, its value is "borderCallout3".</summary>
		BorderCallout3,
		/// <summary>Callout 1 with Border and Accent Shape. When the item is serialized out as xml, its value is "accentBorderCallout1".</summary>
		AccentBorderCallout1,
		/// <summary>Callout 2 with Border and Accent Shape. When the item is serialized out as xml, its value is "accentBorderCallout2".</summary>
		AccentBorderCallout2,
		/// <summary>Callout 3 with Border and Accent Shape. When the item is serialized out as xml, its value is "accentBorderCallout3".</summary>
		AccentBorderCallout3,
		/// <summary>Callout Wedge Rectangle Shape. When the item is serialized out as xml, its value is "wedgeRectCallout".</summary>
		WedgeRectangleCallout,
		/// <summary>Callout Wedge Round Rectangle Shape. When the item is serialized out as xml, its value is "wedgeRoundRectCallout".</summary>
		WedgeRoundRectangleCallout,
		/// <summary>Callout Wedge Ellipse Shape. When the item is serialized out as xml, its value is "wedgeEllipseCallout".</summary>
		WedgeEllipseCallout,
		/// <summary>Callout Cloud Shape. When the item is serialized out as xml, its value is "cloudCallout".</summary>
		CloudCallout,
		/// <summary>Cloud Shape. When the item is serialized out as xml, its value is "cloud".</summary>
		Cloud,
		/// <summary>Ribbon Shape. When the item is serialized out as xml, its value is "ribbon".</summary>
		Ribbon,
		/// <summary>Ribbon 2 Shape. When the item is serialized out as xml, its value is "ribbon2".</summary>
		Ribbon2,
		/// <summary>Ellipse Ribbon Shape. When the item is serialized out as xml, its value is "ellipseRibbon".</summary>
		EllipseRibbon,
		/// <summary>Ellipse Ribbon 2 Shape. When the item is serialized out as xml, its value is "ellipseRibbon2".</summary>
		EllipseRibbon2,
		/// <summary>Left Right Ribbon Shape. When the item is serialized out as xml, its value is "leftRightRibbon".</summary>
		LeftRightRibbon,
		/// <summary>Vertical Scroll Shape. When the item is serialized out as xml, its value is "verticalScroll".</summary>
		VerticalScroll,
		/// <summary>Horizontal Scroll Shape. When the item is serialized out as xml, its value is "horizontalScroll".</summary>
		HorizontalScroll,
		/// <summary>Wave Shape. When the item is serialized out as xml, its value is "wave".</summary>
		Wave,
		/// <summary>Double Wave Shape. When the item is serialized out as xml, its value is "doubleWave".</summary>
		DoubleWave,
		/// <summary>Plus Shape. When the item is serialized out as xml, its value is "plus".</summary>
		Plus,
		/// <summary>Process Flow Shape. When the item is serialized out as xml, its value is "flowChartProcess".</summary>
		FlowChartProcess,
		/// <summary>Decision Flow Shape. When the item is serialized out as xml, its value is "flowChartDecision".</summary>
		FlowChartDecision,
		/// <summary>Input Output Flow Shape. When the item is serialized out as xml, its value is "flowChartInputOutput".</summary>
		FlowChartInputOutput,
		/// <summary>Predefined Process Flow Shape. When the item is serialized out as xml, its value is "flowChartPredefinedProcess".</summary>
		FlowChartPredefinedProcess,
		/// <summary>Internal Storage Flow Shape. When the item is serialized out as xml, its value is "flowChartInternalStorage".</summary>
		FlowChartInternalStorage,
		/// <summary>Document Flow Shape. When the item is serialized out as xml, its value is "flowChartDocument".</summary>
		FlowChartDocument,
		/// <summary>Multi-Document Flow Shape. When the item is serialized out as xml, its value is "flowChartMultidocument".</summary>
		FlowChartMultidocument,
		/// <summary>Terminator Flow Shape. When the item is serialized out as xml, its value is "flowChartTerminator".</summary>
		FlowChartTerminator,
		/// <summary>Preparation Flow Shape. When the item is serialized out as xml, its value is "flowChartPreparation".</summary>
		FlowChartPreparation,
		/// <summary>Manual Input Flow Shape. When the item is serialized out as xml, its value is "flowChartManualInput".</summary>
		FlowChartManualInput,
		/// <summary>Manual Operation Flow Shape. When the item is serialized out as xml, its value is "flowChartManualOperation".</summary>
		FlowChartManualOperation,
		/// <summary>Connector Flow Shape. When the item is serialized out as xml, its value is "flowChartConnector".</summary>
		FlowChartConnector,
		/// <summary>Punched Card Flow Shape. When the item is serialized out as xml, its value is "flowChartPunchedCard".</summary>
		FlowChartPunchedCard,
		/// <summary>Punched Tape Flow Shape. When the item is serialized out as xml, its value is "flowChartPunchedTape".</summary>
		FlowChartPunchedTape,
		/// <summary>Summing Junction Flow Shape. When the item is serialized out as xml, its value is "flowChartSummingJunction".</summary>
		FlowChartSummingJunction,
		/// <summary>Or Flow Shape. When the item is serialized out as xml, its value is "flowChartOr".</summary>
		FlowChartOr,
		/// <summary>Collate Flow Shape. When the item is serialized out as xml, its value is "flowChartCollate".</summary>
		FlowChartCollate,
		/// <summary>Sort Flow Shape. When the item is serialized out as xml, its value is "flowChartSort".</summary>
		FlowChartSort,
		/// <summary>Extract Flow Shape. When the item is serialized out as xml, its value is "flowChartExtract".</summary>
		FlowChartExtract,
		/// <summary>Merge Flow Shape. When the item is serialized out as xml, its value is "flowChartMerge".</summary>
		FlowChartMerge,
		/// <summary>Offline Storage Flow Shape. When the item is serialized out as xml, its value is "flowChartOfflineStorage".</summary>
		FlowChartOfflineStorage,
		/// <summary>Online Storage Flow Shape. When the item is serialized out as xml, its value is "flowChartOnlineStorage".</summary>
		FlowChartOnlineStorage,
		/// <summary>Magnetic Tape Flow Shape. When the item is serialized out as xml, its value is "flowChartMagneticTape".</summary>
		FlowChartMagneticTape,
		/// <summary>Magnetic Disk Flow Shape. When the item is serialized out as xml, its value is "flowChartMagneticDisk".</summary>
		FlowChartMagneticDisk,
		/// <summary>Magnetic Drum Flow Shape. When the item is serialized out as xml, its value is "flowChartMagneticDrum".</summary>
		FlowChartMagneticDrum,
		/// <summary>Display Flow Shape. When the item is serialized out as xml, its value is "flowChartDisplay".</summary>
		FlowChartDisplay,
		/// <summary>Delay Flow Shape. When the item is serialized out as xml, its value is "flowChartDelay".</summary>
		FlowChartDelay,
		/// <summary>Alternate Process Flow Shape. When the item is serialized out as xml, its value is "flowChartAlternateProcess".</summary>
		FlowChartAlternateProcess,
		/// <summary>Off-Page Connector Flow Shape. When the item is serialized out as xml, its value is "flowChartOffpageConnector".</summary>
		FlowChartOffpageConnector,
		/// <summary>Blank Button Shape. When the item is serialized out as xml, its value is "actionButtonBlank".</summary>
		ActionButtonBlank,
		/// <summary>Home Button Shape. When the item is serialized out as xml, its value is "actionButtonHome".</summary>
		ActionButtonHome,
		/// <summary>Help Button Shape. When the item is serialized out as xml, its value is "actionButtonHelp".</summary>
		ActionButtonHelp,
		/// <summary>Information Button Shape. When the item is serialized out as xml, its value is "actionButtonInformation".</summary>
		ActionButtonInformation,
		/// <summary>Forward or Next Button Shape. When the item is serialized out as xml, its value is "actionButtonForwardNext".</summary>
		ActionButtonForwardNext,
		/// <summary>Back or Previous Button Shape. When the item is serialized out as xml, its value is "actionButtonBackPrevious".</summary>
		ActionButtonBackPrevious,
		/// <summary>End Button Shape. When the item is serialized out as xml, its value is "actionButtonEnd".</summary>
		ActionButtonEnd,
		/// <summary>Beginning Button Shape. When the item is serialized out as xml, its value is "actionButtonBeginning".</summary>
		ActionButtonBeginning,
		/// <summary>Return Button Shape. When the item is serialized out as xml, its value is "actionButtonReturn".</summary>
		ActionButtonReturn,
		/// <summary>Document Button Shape. When the item is serialized out as xml, its value is "actionButtonDocument".</summary>
		ActionButtonDocument,
		/// <summary>Sound Button Shape. When the item is serialized out as xml, its value is "actionButtonSound".</summary>
		ActionButtonSound,
		/// <summary>Movie Button Shape. When the item is serialized out as xml, its value is "actionButtonMovie".</summary>
		ActionButtonMovie,
		/// <summary>Gear 6 Shape. When the item is serialized out as xml, its value is "gear6".</summary>
		Gear6,
		/// <summary>Gear 9 Shape. When the item is serialized out as xml, its value is "gear9".</summary>
		Gear9,
		/// <summary>Funnel Shape. When the item is serialized out as xml, its value is "funnel".</summary>
		Funnel,
		/// <summary>Plus Math Shape. When the item is serialized out as xml, its value is "mathPlus".</summary>
		MathPlus,
		/// <summary>Minus Math Shape. When the item is serialized out as xml, its value is "mathMinus".</summary>
		MathMinus,
		/// <summary>Multiply Math Shape. When the item is serialized out as xml, its value is "mathMultiply".</summary>
		MathMultiply,
		/// <summary>Divide Math Shape. When the item is serialized out as xml, its value is "mathDivide".</summary>
		MathDivide,
		/// <summary>Equal Math Shape. When the item is serialized out as xml, its value is "mathEqual".</summary>
		MathEqual,
		/// <summary>Not Equal Math Shape. When the item is serialized out as xml, its value is "mathNotEqual".</summary>
		MathNotEqual,
		/// <summary>Corner Tabs Shape. When the item is serialized out as xml, its value is "cornerTabs".</summary>
		CornerTabs,
		/// <summary>Square Tabs Shape. When the item is serialized out as xml, its value is "squareTabs".</summary>
		SquareTabs,
		/// <summary>Plaque Tabs Shape. When the item is serialized out as xml, its value is "plaqueTabs".</summary>
		PlaqueTabs,
		/// <summary>Chart X Shape. When the item is serialized out as xml, its value is "chartX".</summary>
		ChartX,
		/// <summary>Chart Star Shape. When the item is serialized out as xml, its value is "chartStar".</summary>
		ChartStar,
		/// <summary>Chart Plus Shape. When the item is serialized out as xml, its value is "chartPlus".</summary>
		ChartPlus
	}
}
