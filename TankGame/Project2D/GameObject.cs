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
		protected Matrix3 m_Rotation;

		//Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;


		protected String m_name;
		protected Vector2 m_Position; 
		public GameObject()
		{
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
		}

		public GameObject(string filename, String name)
		{
			m_GlobalTransform.Identity();
			m_LocalTransform.Identity();
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);
			m_name = name;
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
		public virtual void Update(float delta)
		{
			foreach (GameObject child in m_Children)
			{
				child.Update(delta);
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

			foreach(GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}
		 public void Translate(Vector2 delta, bool useGlobal = true)
		{
			if(useGlobal)
			{
			}
			else if(!useGlobal)
			{
				m_LocalTransform.m7 += delta.x;
				m_LocalTransform.m8 += delta.y;
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






		public void GetParent()
		{

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

		public Vector2 GetPosition(Matrix3 current)
		{
			Vector2 position;
			position.x = current.m7;
			position.y = current.m8;
			return position;
		}

		public void SetRotation(float rotate)
		{
			Matrix3 rotateZ = new Matrix3();
			rotateZ.SetRotateZ(rotate);
			m_LocalTransform = m_LocalTransform * rotateZ;
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
		


		public virtual void OnCollision()
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
