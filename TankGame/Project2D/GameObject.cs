<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib;
using static Raylib.Raylib;


namespace Project2D
{
	class GameObject
	{
        #region "Variables" 

        // Random number
        private readonly Random rand = new Random();

		// Parent - Child pairing
		protected GameObject m_Parent;
		protected List<GameObject> m_Children = new List<GameObject>();

		// Matricies
		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;
		
		// Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;
		
		// Collision positional data
		protected Vector2 m_Min;
		protected Vector2 m_Max;
		protected Vector2 m_PreviousPos;

		// Velocity
		protected Vector2 m_Velocity;

		// Item identifiers
		protected string m_name;
		protected bool m_IsAlive = true;
        #endregion

        #region "Constructors"

        // Default constructor for GameObject, used for Level
        public GameObject()
		{
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
		}

		// Loaded constructor for GameObject, used for 
		public GameObject(string filename, string name)
		{
			// Information 
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);
			m_name = name;

			// Collision information
			m_Min.x = -(m_Texture.width * 0.5f);
			m_Min.y = -(m_Texture.height * 0.5f);

			m_Max.x = (m_Texture.width * 0.5f);
			m_Max.y = (m_Texture.height * 0.5f);
		}
        #endregion

        #region "Getters and Setters"
        // Returns the dead/alive state of the item
        public bool GetAlive()
		{
			return m_IsAlive;
		}

		// Sets the dead/alive state of the item
		public void SetAlive(bool alive)
		{
			m_IsAlive = alive;
		}

		// Updates the collision posiition for an item
		public void UpdateMinMax()
		{
			m_Min.x = -(m_Texture.width * 0.5f);
			m_Min.y = -(m_Texture.height * 0.5f);

			m_Max.x = (m_Texture.width * 0.5f);
			m_Max.y = (m_Texture.height * 0.5f);
		}
	
		// Returns the minimum x,y position for item
		public Vector2 GetMin()
		{
			return m_Min;
		}

		// Returns the maximum x,y position for item
		public Vector2 GetMax()
		{
			return m_Max;
		}

		// Sets the parent for a child
		public void SetParent(GameObject newParent)
		{
			// if there is no parent to the child it removes the cild from the parent
			if (newParent == null)
			{
				m_Parent.m_Children.Remove(this);
			}

			m_Parent = newParent;

			// Adds A child to the list of children under a perant
			if (m_Parent != null)
			{
				m_Parent.m_Children.Add(this);
			}
		}

		// returns the parent of the item
		public GameObject GetParent()
		{
			return m_Parent;
		}

		// Returns the list of children for the item
		public List<GameObject> GetChildren()
		{
			return m_Children;
		}

		// Adds a child to the item
		public void AddChild(GameObject child)
		{
			m_Children.Add(child);
		}

		// Removes a child from a parent
		public void RemoveChild(GameObject child)
		{
			m_Children.Remove(child);
		}

		// Creates and returns a "random" x,y position
		public Vector2 GetRandomPos(Vector2 Min, Vector2 Max)
		{
			Vector2 result;
			result.x = rand.Next((int)Min.x, (int)Max.x);
			result.y = rand.Next((int)Min.y, (int)Max.y);
			return result;
		}

		// Creates and returns a "random" 3x3 rotation matix
		public Matrix3 GetRandomRotation()
		{
			Matrix3 rotation = new Matrix3();
			rotation.Identity();
			double radians = Convert.ToDouble(rand.Next(0, 6) + "." + rand.Next(0, 28318530)); ;

			rotation.m1 = (float)Math.Cos(radians);
			rotation.m2 = (float)Math.Sin(radians);
			rotation.m4 = (float)-Math.Sin(radians);
			rotation.m5 = (float)Math.Cos(radians);
			return rotation;
		}

		// Sets the position for the item
		public void SetPosition(Vector2 pos)
		{
			m_LocalTransform.m7 = pos.x;
			m_LocalTransform.m8 = pos.y;
		}

		// Returns the position of the item
		public Vector2 GetPosition()
		{
			Vector2 position;
			position.x = m_LocalTransform.m7;
			position.y = m_LocalTransform.m8;
			return position;
		}

		// Sets the scale for the items locan transform
		public void SetScale(float x, float y)
		{
			m_LocalTransform.m1 = x;
			m_LocalTransform.m5 = y;
		}

		// Returns the scale for the item
		public Vector2 GetScale()
		{
			Vector2 Scale;
			Scale.x = m_LocalTransform.m1;
			Scale.y = m_LocalTransform.m5;
			return Scale;
		}

		// Returns the name of the item
		public string GetName()
		{
			return m_name;
		}
        #endregion

        #region "Transform changes"
        // Rotates the transform 
        public void Rotate(float rotate, bool useGlobal = true)
		{
			// Rotates the global transform
			if (useGlobal)
			{
				Matrix3 rotateZ = new Matrix3();
				rotateZ.SetRotateZ(rotate);
				m_GlobalTransform = m_GlobalTransform * rotateZ;
			}

			// Rotates the local transform
			else if (!useGlobal)
			{
				Matrix3 rotateZ = new Matrix3();
				rotateZ.SetRotateZ(rotate);
				m_LocalTransform = m_LocalTransform * rotateZ;
			}
		}

		// Moves the local transform 
		public void Translate(Vector2 direction, float delta)
		{
			float bSpeed = 400f;
			m_Velocity.x += direction.x * bSpeed * delta;
			m_Velocity.y += direction.y * bSpeed * delta;

			m_LocalTransform.m7 += m_Velocity.x * delta;
			m_LocalTransform.m8 += m_Velocity.y * delta;
		}
		
		// Moves items position
		public void Translate(Vector2 direction, float delta, bool useGlobal = true)
		{
			float mSpeed = 200;
			float drag = 1;
			float mass = 5;
	
			// Adding Mass and Drag to the Velocity
			Vector2 forceSum;
			forceSum.x = direction.x * mSpeed;
			forceSum.y = direction.y * mSpeed;

			Vector2 acceleration;
			acceleration.x = forceSum.x / mass;
			acceleration.y = forceSum.y / mass;

			Vector2 dampening;
			dampening.x = -(m_Velocity.x * drag);
			dampening.y = -(m_Velocity.y * drag);

			m_Velocity.x += (acceleration.x + dampening.x) * delta;
			m_Velocity.y += (acceleration.y + dampening.y) * delta;


			// Changes the global transform
			if (useGlobal)
			{
				// Speeds up the tank to a certain speed
				if (m_Velocity.x * delta < 200 || m_Velocity.y * delta < 200)
				{
					Matrix3 translate = new Matrix3();
					translate.Identity();

					translate.m7 = m_Velocity.x * delta;
					translate.m8 = m_Velocity.y * delta;

					m_GlobalTransform = m_GlobalTransform * translate;
				}
				// Doesnt speed up the tank once it has hit max speed
				else
				{
					return;
				}
			}

			// Changes the local transform
			else if (!useGlobal)
			{
				// Speeds up the tank to a certain speed
				if (m_Velocity.x * delta < 200 || m_Velocity.y * delta < 200)
				{
					Matrix3 translate = new Matrix3();
					translate.Identity();

					translate.m7 = m_Velocity.x * delta;
					translate.m8 = m_Velocity.y * delta;

					m_LocalTransform = m_LocalTransform * translate;
				}
				
				// Doesnt speed up the tank once it has hit max speed
				else
				{
					return;
				}
			}
		}
        #endregion

        #region "Updates"
        // An update function that cycles through all the child's updates
        public virtual void Update(float delta)
		{
			int count = m_Children.Count;

			// Cycles through all the children in the list and calls their update	
			for (int i = 0; i < count; i++)
			{
				m_Children[i].Update(delta);
			}
		}

		// An update function that cycles through all the child's transform updates
		public void UpdateTransforms()
		{
			// If the item has a parent it sets the items transform to its parents global * its local transforms
			if (m_Parent != null)
			{
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			}

			// Sets the items global transform to its local transform
			else
			{
				m_GlobalTransform = m_LocalTransform;
			}

			// Cycles through every child in m_children and calls its transform update
			foreach (GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}

			// Sets the previous position
			if (m_Parent != null)
			{
				m_PreviousPos = GetPosition() - m_Parent.GetPosition();
			}
		}
		
		// Draws the textures for each item
		public void Draw()
		{
			// If the item is alive  it will draw its texture
			if (GetAlive() == true)
			{
				Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());
			}
			// Cycles through all the children in the list
			foreach (GameObject obj in GetChildren())
			{
				obj.Draw();
			}
		}

	

		// An function that is called on Collision
		public virtual void OnCollision(GameObject obj2)
		{
		}

	
	}
    #endregion
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib;
using static Raylib.Raylib;


namespace Project2D
{
	class GameObject
	{
        #region "Variables" 

        // Random number
        private readonly Random rand = new Random();

		// Parent - Child pairing
		protected GameObject m_Parent;
		protected List<GameObject> m_Children = new List<GameObject>();

		// Matricies
		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;
		
		// Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;
		
		// Collision positional data
		protected Vector2 m_Min;
		protected Vector2 m_Max;
		protected Vector2 m_PreviousPos;

		// Velocity
		protected Vector2 m_Velocity;

		// Item identifiers
		protected string m_name;
		protected bool m_IsAlive = true;
        #endregion

        #region "Constructors"

        // Default constructor for GameObject, used for Level
        public GameObject()
		{
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
		}

		// Loaded constructor for GameObject, used for 
		public GameObject(string filename, string name)
		{
			// Information 
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);
			m_name = name;

			// Collision information
			m_Min.x = -(m_Texture.width * 0.5f);
			m_Min.y = -(m_Texture.height * 0.5f);

			m_Max.x = (m_Texture.width * 0.5f);
			m_Max.y = (m_Texture.height * 0.5f);
		}
        #endregion

        #region "Getters and Setters"
        // Returns the dead/alive state of the item
        public bool GetAlive()
		{
			return m_IsAlive;
		}

		// Sets the dead/alive state of the item
		public void SetAlive(bool alive)
		{
			m_IsAlive = alive;
		}

		// Updates the collision posiition for an item
		public void UpdateMinMax()
		{
			m_Min.x = -(m_Texture.width * 0.5f);
			m_Min.y = -(m_Texture.height * 0.5f);

			m_Max.x = (m_Texture.width * 0.5f);
			m_Max.y = (m_Texture.height * 0.5f);
		}
	
		// Returns the minimum x,y position for item
		public Vector2 GetMin()
		{
			return m_Min;
		}

		// Returns the maximum x,y position for item
		public Vector2 GetMax()
		{
			return m_Max;
		}

		// Sets the parent for a child
		public void SetParent(GameObject newParent)
		{
			// if there is no parent to the child it removes the cild from the parent
			if (newParent == null)
			{
				m_Parent.m_Children.Remove(this);
			}

			m_Parent = newParent;

			// Adds A child to the list of children under a perant
			if (m_Parent != null)
			{
				m_Parent.m_Children.Add(this);
			}
		}

		// returns the parent of the item
		public GameObject GetParent()
		{
			return m_Parent;
		}

		// Returns the list of children for the item
		public List<GameObject> GetChildren()
		{
			return m_Children;
		}

		// Adds a child to the item
		public void AddChild(GameObject child)
		{
			m_Children.Add(child);
		}

		// Removes a child from a parent
		public void RemoveChild(GameObject child)
		{
			m_Children.Remove(child);
		}

		// Creates and returns a "random" x,y position
		public Vector2 GetRandomPos(Vector2 Min, Vector2 Max)
		{
			Vector2 result;
			result.x = rand.Next((int)Min.x, (int)Max.x);
			result.y = rand.Next((int)Min.y, (int)Max.y);
			return result;
		}

		// Creates and returns a "random" 3x3 rotation matix
		public Matrix3 GetRandomRotation()
		{
			Matrix3 rotation = new Matrix3();
			rotation.Identity();
			double radians = Convert.ToDouble(rand.Next(0, 6) + "." + rand.Next(0, 28318530)); ;

			rotation.m1 = (float)Math.Cos(radians);
			rotation.m2 = (float)Math.Sin(radians);
			rotation.m4 = (float)-Math.Sin(radians);
			rotation.m5 = (float)Math.Cos(radians);
			return rotation;
		}

		// Sets the position for the item
		public void SetPosition(Vector2 pos)
		{
			m_LocalTransform.m7 = pos.x;
			m_LocalTransform.m8 = pos.y;
		}

		// Returns the position of the item
		public Vector2 GetPosition()
		{
			Vector2 position;
			position.x = m_LocalTransform.m7;
			position.y = m_LocalTransform.m8;
			return position;
		}

		// Sets the scale for the items locan transform
		public void SetScale(float x, float y)
		{
			m_LocalTransform.m1 = x;
			m_LocalTransform.m5 = y;
		}

		// Returns the scale for the item
		public Vector2 GetScale()
		{
			Vector2 Scale;
			Scale.x = m_LocalTransform.m1;
			Scale.y = m_LocalTransform.m5;
			return Scale;
		}

		// Returns the name of the item
		public string GetName()
		{
			return m_name;
		}
        #endregion

        #region "Transform changes"
        // Rotates the transform 
        public void Rotate(float rotate, bool useGlobal = true)
		{
			// Rotates the global transform
			if (useGlobal)
			{
				Matrix3 rotateZ = new Matrix3();
				rotateZ.SetRotateZ(rotate);
				m_GlobalTransform = m_GlobalTransform * rotateZ;
			}

			// Rotates the local transform
			else if (!useGlobal)
			{
				Matrix3 rotateZ = new Matrix3();
				rotateZ.SetRotateZ(rotate);
				m_LocalTransform = m_LocalTransform * rotateZ;
			}
		}

		// Moves the local transform 
		public void Translate(Vector2 direction, float delta)
		{
			float bSpeed = 400f;
			m_Velocity.x += direction.x * bSpeed * delta;
			m_Velocity.y += direction.y * bSpeed * delta;

			m_LocalTransform.m7 += m_Velocity.x * delta;
			m_LocalTransform.m8 += m_Velocity.y * delta;
		}
		
		// Moves items position
		public void Translate(Vector2 direction, float delta, bool useGlobal = true)
		{
			float mSpeed = 200;
			float drag = 1;
			float mass = 5;
	
			// Adding Mass and Drag to the Velocity
			Vector2 forceSum;
			forceSum.x = direction.x * mSpeed;
			forceSum.y = direction.y * mSpeed;

			Vector2 acceleration;
			acceleration.x = forceSum.x / mass;
			acceleration.y = forceSum.y / mass;

			Vector2 dampening;
			dampening.x = -(m_Velocity.x * drag);
			dampening.y = -(m_Velocity.y * drag);

			m_Velocity.x += (acceleration.x + dampening.x) * delta;
			m_Velocity.y += (acceleration.y + dampening.y) * delta;


			// Changes the global transform
			if (useGlobal)
			{
				// Speeds up the tank to a certain speed
				if (m_Velocity.x * delta < 200 || m_Velocity.y * delta < 200)
				{
					Matrix3 translate = new Matrix3();
					translate.Identity();

					translate.m7 = m_Velocity.x * delta;
					translate.m8 = m_Velocity.y * delta;

					m_GlobalTransform = m_GlobalTransform * translate;
				}
				// Doesnt speed up the tank once it has hit max speed
				else
				{
					return;
				}
			}

			// Changes the local transform
			else if (!useGlobal)
			{
				// Speeds up the tank to a certain speed
				if (m_Velocity.x * delta < 200 || m_Velocity.y * delta < 200)
				{
					Matrix3 translate = new Matrix3();
					translate.Identity();

					translate.m7 = m_Velocity.x * delta;
					translate.m8 = m_Velocity.y * delta;

					m_LocalTransform = m_LocalTransform * translate;
				}
				
				// Doesnt speed up the tank once it has hit max speed
				else
				{
					return;
				}
			}
		}
        #endregion

        #region "Updates"
        // An update function that cycles through all the child's updates
        public virtual void Update(float delta)
		{
			int count = m_Children.Count;

			// Cycles through all the children in the list and calls their update	
			for (int i = 0; i < count; i++)
			{
				m_Children[i].Update(delta);
			}
		}

		// An update function that cycles through all the child's transform updates
		public void UpdateTransforms()
		{
			// If the item has a parent it sets the items transform to its parents global * its local transforms
			if (m_Parent != null)
			{
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			}

			// Sets the items global transform to its local transform
			else
			{
				m_GlobalTransform = m_LocalTransform;
			}

			// Cycles through every child in m_children and calls its transform update
			foreach (GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}

			// Sets the previous position
			if (m_Parent != null)
			{
				m_PreviousPos = GetPosition() - m_Parent.GetPosition();
			}
		}
		
		// Draws the textures for each item
		public void Draw()
		{
			// If the item is alive  it will draw its texture
			if (GetAlive() == true)
			{
				Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());
			}
			// Cycles through all the children in the list
			foreach (GameObject obj in GetChildren())
			{
				obj.Draw();
			}
		}

	

		// An function that is called on Collision
		public virtual void OnCollision(GameObject obj2)
		{
		}

	
	}
    #endregion
}
>>>>>>> Stashed changes
