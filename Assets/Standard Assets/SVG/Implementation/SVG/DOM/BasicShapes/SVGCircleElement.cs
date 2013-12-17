public class SVGCircleElement : SVGTransformable, ISVGDrawable {
  private SVGLength _cx;
  private SVGLength _cy;
  private SVGLength _r;
  //================================================================================
  private SVGGraphics _render;
  private AttributeList _attrList;
  private SVGPaintable _paintable;
  //================================================================================
  public SVGLength cx {
    get {
      return this._cx;
    }
  }

  public SVGLength cy {
    get {
      return this._cy;
    }
  }

  public SVGLength r {
    get {
      return this._r;
    }
  }
  //================================================================================
  public SVGCircleElement(AttributeList attrList,
              SVGTransformList inheritTransformList,
              SVGPaintable inheritPaintable,
              SVGGraphics _render) : base(inheritTransformList) {
    this._attrList = attrList;
    this._render = _render;
    this._paintable = new SVGPaintable(inheritPaintable, this._attrList);
    this._cx = new SVGLength(attrList.GetValue("cx"));
    this._cy = new SVGLength(attrList.GetValue("cy"));
    this._r = new SVGLength(attrList.GetValue("r"));
  }
  //================================================================================
  private SVGGraphicsPath _graphicsPath;
  private void CreateGraphicsPath() {
    this._graphicsPath = new SVGGraphicsPath();

    this._graphicsPath.Add(this);
    this._graphicsPath.transformList = this.summaryTransformList;
  }
  //-----
  private void Draw() {
    if(this._paintable.strokeColor == null)return;

    this._render.DrawPath(this._graphicsPath, this._paintable.strokeWidth,
                            this._paintable.strokeColor);
  }
  //================================================================================
  //Thuc thi Interface Drawable
  public void BeforeRender(SVGTransformList transformList) {
    this.inheritTransformList = transformList;
  }
  //------
  public void Render() {
    CreateGraphicsPath();
    this._render.SetStrokeLineCap(this._paintable.strokeLineCap);
    this._render.SetStrokeLineJoin(this._paintable.strokeLineJoin);
    switch(this._paintable.GetPaintType()) {
      case SVGPaintMethod.SolidGradientFill : {
        this._render.FillPath(this._paintable.fillColor.Value, this._graphicsPath);
        Draw();
        break;
      }
      case SVGPaintMethod.LinearGradientFill : {

        SVGLinearGradientBrush _linearGradBrush =
                  this._paintable.GetLinearGradientBrush(this._graphicsPath);

        if(_linearGradBrush != null) {
          this._render.FillPath(_linearGradBrush, _graphicsPath);
        }
        Draw();
        break;
      }
      case SVGPaintMethod.RadialGradientFill : {
        SVGRadialGradientBrush _radialGradBrush =
                  this._paintable.GetRadialGradientBrush(this._graphicsPath);

        if(_radialGradBrush != null) {
          this._render.FillPath(_radialGradBrush, _graphicsPath);
        }
        Draw();
        break;
      }
      case SVGPaintMethod.PathDraw : {
        Draw();
        break;
      }
    }
  }
}
