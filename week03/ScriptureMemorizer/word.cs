public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hidden = "";
            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                    hidden += "_";
                else
                    hidden += c;
            }
            return hidden;
        }
        else
        {
            return _text;
        }
    }
}
