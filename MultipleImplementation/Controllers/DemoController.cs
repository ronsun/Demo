using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleImplementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private IEnumerable<IFoo> _allFoo;
        private IReadOnlyDictionary<string, IBar> _allBar;
        private IBazBridge _bazBridge;

        public DemoController(
            IEnumerable<IFoo> allFoo,
            IReadOnlyDictionary<string, IBar> allBar,
            IBazBridge bazBridge)
        {
            _allFoo = allFoo;
            _allBar = allBar;
            _bazBridge = bazBridge;
        }

        [HttpGet]
        public ActionResult<string> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Please correct request, ex: https://localhost:44330/Demo?name=[the name]");
            }

            var sb = new StringBuilder();

            // foo
            var foo = _allFoo.FirstOrDefault(r => r.Name == name);
            sb.Append(foo?.Hi());

            // bar
            _allBar.TryGetValue(name, out IBar bar);
            sb.Append(bar?.Hello());

            // baz
            sb.Append(_bazBridge.Hey(name));

            return Ok(sb.ToString());
        }
    }
}

#region INameable

public interface INameable
{
    string Name { get; }
}

#endregion

#region About Foo

public interface IFoo : INameable
{
    string Hi();
}

internal class Foo1 : IFoo
{
    public string Name => "Foo1";

    public string Hi()
    {
        return "Hi, this is Foo1";
    }
}

internal class Foo2 : IFoo
{
    public string Name => "Foo2";

    public string Hi()
    {
        return "Hi, this is Foo2";
    }
}

#endregion

#region About Bar

public interface IBar : INameable
{
    string Hello();
}

internal class Bar1 : IBar
{
    public string Name => "Bar1";

    public string Hello()
    {
        return "Hello, this is Bar1";
    }
}

internal class Bar2 : IBar
{
    public string Name => "Bar2";

    public string Hello()
    {
        return "Hello, this is Bar2";
    }
}

#endregion

#region About Baz

public interface IBaz : INameable
{
    string Hey();
}

internal class Baz1 : IBaz
{
    public string Name => "Baz1";

    public string Hey()
    {
        return "Hey, this is Baz1";
    }
}

internal class Baz2 : IBaz
{
    public string Name => "Baz2";

    public string Hey()
    {
        return "Hey, this is Baz2";
    }
}

public interface IBazBridge
{
    string Hey(string name);
}

internal class BazBridge : IBazBridge
{
    private IReadOnlyDictionary<string, IBaz> _allBazDictionary;

    public BazBridge(IEnumerable<IBaz> allBaz)
    {
        _allBazDictionary = allBaz.ToDictionary(baz => baz.Name, baz => baz);
    }

    public string Hey(string name)
    {
        _allBazDictionary.TryGetValue(name, out IBaz baz);
        return baz?.Hey();
    }
}

#endregion