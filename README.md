Lerp-Unity-Sample
=========================

Suddenly, I pondered on how to create motion or movement using interpolation in mathematics. Until now, I realized I've only been using linear motion, and it looks rigid. I desire effects like ease-in (coserp), ease-out (sinerp), and exponential movement in the game UI I'm developing. UnityEngine provides the method Lerp, short for Linear intERPolation, which we can find in Vector2, Vector3, Color, and Mathf. There are indeed many ways to create simple movement in games, such as Translate, changing transform values, or using plugins like DotTween Pro, iTween, GoKit, or Hotween.

Then the question arises, "How do I implement ease-in and ease-out movements without using plugins?" Yes, using plugins is a shortcut to save time in production, but aren't you curious about how it works? Here's my research repository on Lerp in Unity. In this repository, there's a collection of formulas for creating simple movements like ease-in, ease-out, exponential, smoothStep, smootherDump that I created in my spare time. Actually, it's for my own reference because I tend to forget the formulas. I hope it's helpful.


