using System;
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
		//translation * rotation * scale

		protected GameObject m_Parent;
		protected List<GameObject> m_Children = new List<GameObject>();

		//Matricies
		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;

		//Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;

		protected Vector2 m_Min;
		protected Vector2 m_Max;
		protected Vector2 m_PreviousPos;


		protected Vector2 m_Velocity;

		protected string m_name;

		protected bool m_IsAlive = true;

		public GameObject()
		{
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
		}

		public GameObject(string filename, string name)
		{
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);
			m_name = name;


			m_Min.x = -(m_Texture.width * 0.5f);
			m_Min.y = -(m_Texture.height * 0.5f);

			m_Max.x = (m_Texture.width * 0.5f);
			m_Max.y = (m_Texture.height * 0.5f);
		}


		public bool GetAlive()
		{
			return m_IsAlive;
		}

		public void UpdateMinMax()
		{
			m_Min.x = -(m_Texture.width * 0.5f);
			m_Min.y = -(m_Texture.height * 0.5f);

			m_Max.x = (m_Texture.width * 0.5f);
			m_Max.y = (m_Texture.height * 0.5f);
		}
		public void SetAlive(bool alive)
		{
			alive = m_IsAlive;
		}


		public Vector2 GetMin()
		{

			return m_Min;
		}

		public Vector2 GetMax()
		{

			return m_Max;
		}

		public void SetParent(GameObject newParent)
		{
			
			if (newParent == null)
			{
				m_Parent.m_Children.Remove(this);
			}

			m_Parent = newParent;

			if (m_Parent != null)
			{
				m_Parent.m_Children.Add(this);	
			}	
			
		}


		public GameObject GetParent()
		{

			return m_Parent;

		}

		public virtual void Update(float delta)
		{
			int count = m_Children.Count;
			for(int i = 0; i < count; i ++)
			{
				m_Children[i].Update(delta);
			}
		}

		public void UpdateTransforms()
		{

			if (m_Parent != null)
			{
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			}

			else
			{
				m_GlobalTransform = m_LocalTransform;
			}

			foreach (GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
			if (m_Parent != null)
			{
				m_PreviousPos = GetPosition() - m_Parent.GetPosition();
			}
			else
			{

			}

		}
        public void Translate(Vector2 direction, float delta)
        {
            float bSpeed = 400;
            m_Velocity.x += direction.x * bSpeed * delta;
            m_Velocity.y += direction.y * bSpeed * delta;

            m_LocalTransform.m7 += m_Velocity.x * delta;
            m_LocalTransform.m8 += m_Velocity.y * delta;
        }


        public void Translate(Vector2 direction ,float delta, bool useGlobal = true)
		{
			float mSpeed = 200;
			float drag = 1;
			float mass = 5;

			//Vector2 currentPos;
			//currentPos.x = m_LocalTransform.m7;
			//currentPos.y = m_LocalTransform.m8;

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



			if (useGlobal)
			{
			}
			else if(!useGlobal)
			{
			

				// Acts to spead up the tank under a certain speed
				if (m_Velocity.x * delta < 200 || m_Velocity.y * delta < 200)
				{
					Matrix3 translate = new Matrix3();
					translate.Identity();

					translate.m7 = m_Velocity.x * delta;
					translate.m8 = m_Velocity.y * delta;

					m_LocalTransform = m_LocalTransform * translate;


				}
				else
                {
					return;
                }


				//Speed counter
			//	int fSpeed;
			//	Vector2 distance;
			//	distance.x = (currentPos.x * delta) - (m_Velocity.x * delta);
			//	distance.y = (currentPos.y * delta) - (m_Velocity.y * delta);
			//	fSpeed = (int)(distance.x / delta);

	

			//	DrawText(fSpeed.ToString(), 10, 30, 14, RLColor.RED);
			}
		}

		public void UpdateRotations()
		{

		}

		public void Draw()
		{
		
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());

			foreach (GameObject obj in GetChildren())
			{
				obj.Draw();
			}
		}

		public List<GameObject> GetChildren()
		{
			return m_Children;
		}


		public void AddChild(GameObject child)
		{
			m_Children.Add(child);
		}

		public void RemoveChild(GameObject child)
		{
			m_Children.Remove(child);
		}

		public void SetPosition(Vector2 pos)
		{
			Matrix3 position;
			position.m7 = pos.x;
			position.m8 = pos.y;
		}

		public Vector2 GetPosition()
		{
			Vector2 position;
			position.x = m_LocalTransform.m7;
			position.y = m_LocalTransform.m8;
			return position;
		}

		public void Rotate(float rotate, bool useGlobal = true)
		{
			if (useGlobal)
			{
			}
			else if (!useGlobal)
			{
				Matrix3 rotateZ = new Matrix3();
				rotateZ.SetRotateZ(rotate);
				m_LocalTransform = m_LocalTransform * rotateZ;
			}
		}
		public void GetRotation()
		{

		}

		public void SetScale(Matrix3 current, float x, float y)
		{
			current.m1 = x;
			current.m5 = y;
		}

		public Vector2 GetScale(Matrix3 current)
		{
			Vector2 Scale;
			Scale.x = current.m1;
			Scale.y = current.m5;

			return Scale;
		}
		


		public virtual void OnCollision(GameObject obj2)
		{
		}
		
		public void GetRadius()
		{
		}
		
		public void SetRadius()
		{
		}

	}
}
