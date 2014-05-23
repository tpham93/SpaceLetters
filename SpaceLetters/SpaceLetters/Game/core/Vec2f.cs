using SFML.Window;
using System;

/// <summary>
/// Vector2f wrapper with some simple methods and implicit casting to Vector2f, so you can use Vec2f everywhere, where Vecto2f is used.
/// </summary>
public struct Vec2f
{
    //////////////////////___MEMBER___////////////////////////////
    Vector2f vec;

    /// <summary>
    /// The x component of the vector.
    /// </summary>
    public float X 
    { 
        get 
        {
            return vec.X; 
        } 
        set 
        { 
            vec.X = value; 
        } 
    }

    /// <summary>
    /// The y component of the vector.
    /// </summary>
    public float Y
    {
        get
        {
            return vec.Y;
        }
        set
        {
            vec.Y = value;
        }
    }
    
    //////////////////////___CONSTRUCTORS___//////////////////////

    public Vec2f(float x, float y)
    {
        this.vec.X = x;
        this.vec.Y = y;
    }

    public Vec2f(Vec2f f2)
    {
        vec = new Vector2f(f2.X, f2.Y);
    }

    public Vec2f(Vector2f f2)
    {
        this.vec = f2;
    }


    //////////////////////___METHODS___//////////////////////

    /// <summary>
    /// Normalizes this Vec2f. If the length is 0, nothing happens.
    /// </summary>
    public void normalize()
    {
        float l = length();

        if (l == 0)
            return;

        this  = this / l;
    }

    /// <summary>
    /// Creates a new Vec2f and normalizes it.
    /// </summary>
    /// <returns>The normalized Vec2f</returns>
    public Vec2f normalized()
    {
        float l = length();

        if (l == 0)
            return new Vec2f(this);

        return this / l;
    }

    /// <summary>
    /// Computes the length of the Vec2f.
    /// </summary>
    /// <returns>Length of the Vec2f.</returns>
    public float length()
    {
        return (float)Math.Sqrt(lengthSq());
    }

    /// <summary>
    /// Computes the squared length of this Vec2f.
    /// </summary>
    /// <returns>Squared length of this Vec2f.</returns>
    public float lengthSq()
    {
        return this.X * this.X + this.Y * this.Y;
    }

    /// <summary>
    /// Computes the euclidian distance between this Vec2f and f2.
    /// </summary>
    /// <param name="f2"></param>
    /// <returns>Distance from this to f2.</returns>
    public float distance(Vec2f f2)
    {
        return (this - f2).length();
    }

    /// <summary>
    /// Computes the squared distance between this Vec2f and f2.
    /// </summary>
    /// <param name="f2"></param>
    /// <returns>Squared distance from this to f2.</returns>
    public float distanceSq(Vec2f f2)
    {
        return (this - f2).lengthSq();
    }

    /// <summary>
    /// Computes the dot product (scalar product) between this Vec2f and f2.
    /// </summary>
    /// <param name="f2"></param>
    /// <returns></returns>
    public float dot(Vec2f f2)
    {
        return this.X * f2.X + this.Y * f2.Y;
    }

    public override string ToString()
    {
        return "X: " + this.X + ", Y: " + this.Y;
    }

    //////////////////////___STATICS___/////////////////////////////


    /// <summary>
    /// Calculates a linear interpolation between f1 and f2 with the amout t.
    /// </summary>
    /// <param name="f1">Start Vec2f.</param>
    /// <param name="f2">End Vec2f.</param>
    /// <param name="t">Amount of interpolation. Should be [0,1] for correct interpolation.</param>
    /// <returns>A new Vec2f that is "between" f1 and f2.</returns>
    public static Vec2f lerp(Vec2f f1, Vec2f f2, float t)
    {
        return (1 - t) * f1 + t * f2;
    }
    


    //operator overloading:

    /// <summary>
    /// Vector-vector addition.
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
    public static Vec2f operator + (Vec2f f1, Vec2f f2)
    {
        return new Vec2f(f1.X + f2.X, f1.Y + f2.Y);
    }

    /// <summary>
    /// Vector-vector subtraction.
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
    public static Vec2f operator - (Vec2f f1, Vec2f f2)
    {
        return new Vec2f(f1.X - f2.X, f1.Y - f2.Y);
    }

    /// <summary>
    /// Negation of a vector.
    /// </summary>
    /// <param name="f1"></param>
    /// <returns></returns>
    public static Vec2f operator - (Vec2f f1)
    {
        return new Vec2f(-f1.X, -f1.Y);
    }

    /// <summary>
    /// Scalar-vector multiplication. Mutliplies the x and y component of the Vec2f with z.
    /// </summary>
    /// <param name="z"></param>
    /// <param name="f1"></param>
    /// <returns></returns>
    public static Vec2f operator * (float z, Vec2f f1)
    {
        return new Vec2f(z * f1.X, z * f1.Y);
    }

    /// <summary>
    /// Scalar-vector multiplication. Mutliplies the x and y component of the Vec2f with z.
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public static Vec2f operator * (Vec2f f1, float z)
    {
        return new Vec2f(f1.X * z, f1.Y * z);
    }

    /// <summary>
    /// Vector-scaler division.
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public static Vec2f operator /(Vec2f f1, float z)
    {
        return new Vec2f(f1.X / z, f1.Y/ z);
    }

    //implicit castings: Vec2f <-> Vector2f (SFML)

    /// <summary>
    /// Implicit cast to Vector2f
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static implicit operator Vector2f(Vec2f v)
    {
        return v.vec;
    }

    /// <summary>
    /// Implicit cast to Vec2f
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static implicit operator Vec2f(Vector2f v)
    {
        return new Vec2f(v);
    }

}

