# Description

We are aiming to make a program which displays a random image received from an API whenever the user clicks the "Get Image" button.

The program retrieves a link of a random image from the API when the user clicks the "Get Image" button, and sets the "Source" property of the "mainImage" to that retrieved link. 

The `GetImage` event handler method is binded to the `Clicked` EventHandler of the button. So whenever the user clicks the button, the program executes that method and makes a get request to the URL `https://random.imagecdn.app/v1/image`. 

When the method receives a response from the API, it extracts the content from the response - which is expected to be a raw URL (link) of an image. And it passes that as a string into the `OnApiResponse` method which is to be defined by you.

The `OnApiResponse` method should execute the EventHandler of the apiEvent class which you're going to create. Moreover, it should pass the "content" forward into the event handler methods as an argument and for that you can use the `apiEventArgs` which has already been defined for you. You can store the content in the `Link` property of a new `apiEventArgs` instance and pass it as a second argument to the event handler execution.
```
handler(this, new apiEventArgs(content));
```

So this will be the who flow of the program:
1. The user clicks **Get Image**;
2. Program makes a **GET request**;
3. The **API** responds with the **URL** of a random image;
4. The **URL** is passed as a `string` to `OnApiResponse` method of the `apiEvent` class;
5. The **EventHandler** of `apiEvent` class is **invoked**, in turn invoking all binded methods (event handlers);
6. The **URL** is sent the binded **Event Handlers**, hence invoking the **SetImage** method;
7. The image is shown on the screen;

### Learning Objective: 
You might be wondering, what was the need for creating this seemingly unnecessary "cycle". We could've simply written `mainImage.Source = content` directly inside the `GetImage` method where the API response is received, and by doing that we could've avoided creating the whole Event System around the API call. Moreover, In that case the program execution and code would've been much shorter:

1. The user clicks **Get Image**;
2. Program makes a **GET request**;
3. The API responds with a **URL** of a random image;
4. The new image is shown on the screen;

However one **benefit** of creating the `apiEvent` is that **we can use this event globally** in the application. Which allows us to **bind methods** to the Event Handler of this event **from multiple different external classes**.

You basically have to replicate the "Publisher" class from the following diagram:
![Diagram](https://codefinity-content-media-v2.s3.eu-west-1.amazonaws.com/courses/c585e6db-0d47-4d9a-aa26-c1a0358614c8/S2/image2.png)

### Your Task
Following is a concise description of your task:
1. Create a new public class called `apiEvent`
2. Create a delegate type called `apiEventHandler` which can accept `apiEventArgs` as a second argument.
3. Create a public delegate using the recently defined delegate type. Call it `OnResponse`.
4. Create a delegate invoker method called `OnApiResponse` and it should accept one `string` argument. You may name the argument as "content".
5. Inside `OnApiResponse`, invoke the delegate if it's not null and pass the value of "content" to the event handler methods by using the `apiEventArgs` method.
