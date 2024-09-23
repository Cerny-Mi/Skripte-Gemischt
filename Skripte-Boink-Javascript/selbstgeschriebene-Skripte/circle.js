class Particle {
  constructor(x, y, r, hu, fixed= false) {
    this.x = x;
    this.y = y;
    this.r = r;
    this.hu = hu; //hue
    this.fixed = fixed;
    
    let options = {
      friction: 0.99,
      restitution: 0.01,
      isStatic: fixed,
     // density: 1,
      frictionAir: 0.04  //default =0.01
    };
    this.body = Bodies.circle(this.x, this.y, this.r, options);
    
    this.body.label = "ball";
    
    //Composite.add(world, this.body);
    World.add(world, this.body); 
  } //const END

  show() {
    //inputX=0, inputY=0

    //default:
    let pos = this.body.position;
    let fix = this.fixed;
    //let angle = this.body.angle;
    push();
    colorMode(HSB);
    translate(pos.x, pos.y);
    //will it move with me if there is no rotate??
  //  rotate(angle);
    rectMode(CENTER);


    if(fix === false) // wenn scirc
    {noStroke();
    fill(this.hu, 80,80); //gives it an hsb-color, decided upon creation of the element
    ellipse(0, 0, sCircSizeControl * 2);
}

if(fix === true) // wenn sgoal
{noFill();
  strokeWeight(3);
 
 
 if (_adds) brightness= brightness + brightnessAdder;
 if (!_adds)brightness= brightness - brightnessAdder;
 
stroke(this.hu, 80,brightness); //gives it an hsb-color, decided upon creation of the element
ellipse(0, 0, this.r * 2.5);
}

     
if(brightness >= 100) _adds = false;
if(brightness <= 10) _adds = true;

    
    pop();
  } //show END

  removeFromWorld() {
    World.remove(world, this.body);
  } //remove END
} //class END
