public class B : A
{
    // Class B extends A

    public B()
    {
        base.A("Instancia de B");
    }

    public string M4()
    {
        return "M�todo del hijo Invocado";
    }

}