class Boundary {
  constructor(x, y, w, h, a, _visible = false) {
    this.x = x;
    this.y = y;
    this.w = w;
    this.h = h;
    
    this._visible = _visible; //bool to say if shape gets a fill and stroke or nothing at all
    //given default = true

    let options = {
      friction: 1,
      restitution: 0,
      angle: a,
      isStatic: true,
      //density: 1
      // collisionFilter: canCollideWithWalls
    };
    this.body = Bodies.rectangle(this.x, this.y, this.w, this.h, options);
    
    this.body.label = "boundary";
    
     //Composite.add(world, this.body);
    World.add(world, this.body); 
  }

  show() {
    let pos = this.body.position;
    let angle = this.body.angle;
    let _visible = this._visible;

    push();
    translate(pos.x, pos.y);
    angleMode(DEGREES);
    rotate(angle);
    rectMode(CENTER);

    if (_visible) {
      strokeWeight(1);
      stroke(255);
      noFill();
    } else {
      //display nothing
      noFill();
      noStroke();
    }

    rect(0, 0, this.w, this.h);
    pop();
  }
}
