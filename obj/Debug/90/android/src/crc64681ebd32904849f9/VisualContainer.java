package crc64681ebd32904849f9;


public class VisualContainer
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfDataGrid.VisualContainer, Syncfusion.SfDataGrid.Android", VisualContainer.class, __md_methods);
	}


	public VisualContainer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == VisualContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.VisualContainer, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public VisualContainer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == VisualContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.VisualContainer, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public VisualContainer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == VisualContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.VisualContainer, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public VisualContainer (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == VisualContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.VisualContainer, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
