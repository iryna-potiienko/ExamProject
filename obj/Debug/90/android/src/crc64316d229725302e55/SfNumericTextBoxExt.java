package crc64316d229725302e55;


public class SfNumericTextBoxExt
	extends crc645adc4b20c7f8e944.SfNumericTextBox
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFocusChanged:(ZILandroid/graphics/Rect;)V:GetOnFocusChanged_ZILandroid_graphics_Rect_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfDataGrid.Android.SfNumericTextBoxExt, Syncfusion.SfDataGrid.Android", SfNumericTextBoxExt.class, __md_methods);
	}


	public SfNumericTextBoxExt (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfNumericTextBoxExt.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.Android.SfNumericTextBoxExt, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SfNumericTextBoxExt (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfNumericTextBoxExt.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.Android.SfNumericTextBoxExt, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfNumericTextBoxExt (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfNumericTextBoxExt.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.Android.SfNumericTextBoxExt, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfNumericTextBoxExt (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SfNumericTextBoxExt.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.Android.SfNumericTextBoxExt, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onFocusChanged (boolean p0, int p1, android.graphics.Rect p2)
	{
		n_onFocusChanged (p0, p1, p2);
	}

	private native void n_onFocusChanged (boolean p0, int p1, android.graphics.Rect p2);

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
