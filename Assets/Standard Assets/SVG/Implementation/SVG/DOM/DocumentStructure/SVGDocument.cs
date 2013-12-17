
public class SVGDocument {
  private SVGSVGElement _rootElement = null;
  private SVGGraphics _render;
  /***********************************************************************************/
  public SVGSVGElement rootElement {
    get {
      if(_rootElement == null) {
        while(!parser.IsEOF && parser.Node.Name != SVGNodeName.SVG)
          parser.Next();
        _rootElement = new SVGSVGElement(parser, new SVGTransformList(), new SVGPaintable(), _render);
      }
      return _rootElement;
    }
  }
  /***********************************************************************************/
  //_nodeByTagName la 1 dictionary de luu tru cac Element ton tai ben trong 1 SVG Document
  //private Dictionary<string, SVGElement> _nodeByTagName = new Dictionary<string, SVGElement>();
  /***********************************************************************************/
  private SVGParser parser;
  public SVGDocument(string originalDocument, SVGGraphics r) {
    parser = new SVGParser(originalDocument);
    _render = r;
  }
}
