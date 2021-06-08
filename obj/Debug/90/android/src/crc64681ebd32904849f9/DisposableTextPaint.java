package crc64681ebd32904849f9;


public class DisposableTextPaint
	extends android.text.TextPaint
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_finalize:()V:GetJavaFinalizeHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfDataGrid.DisposableTextPaint, Syncfusion.SfDataGrid.Android", DisposableTextPaint.class, __md_methods);
	}


	public DisposableTextPaint ()
	{
		super ();
		if (getClass () == DisposableTextPaint.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableTextPaint, Syncfusion.SfDataGrid.Android", "", this, new java.lang.Object[] {  });
	}


	public DisposableTextPaint (android.graphics.Paint p0)
	{
		super (p0);
		if (getClass () == DisposableTextPaint.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableTextPaint, Syncfusion.SfDataGrid.Android", "Android.Graphics.Paint, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public DisposableTextPaint (int p0)
	{
		super (p0);
		if (getClass () == DisposableTextPaint.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableTextPaint, Syncfusion.SfDataGrid.Android", "Android.Graphics.PaintFlags, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void finalize ()
	{
		n_finalize ();
	}

	private native void n_finalize ();

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
