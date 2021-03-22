using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;
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
		protected Matrix3 m_scale;

		//Drawing
		protected Image m_Image;
		protected Texture2D m_Texture;

		protected float m_CollisionRadius;


		public GameObject(string filename)
		{
			m_Image = LoadImage(filename);
			m_Texture = LoadTextureFromImage(m_Image);
		}
		public void SetParent(GameObject parent)
		{
			//remove from previous parent
			if (parent == null)
			{
				parent.m_Children.Add(this);
			}

			if (parent != null)
			{
				parent.m_Children.Remove(this);
			}
			
		}

		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());
		}






		public void GetParent()
		{

		}

		public void AddChild(GameObject child)
		{
			m_Children.Add(this);
		}

		public void RemoveChild(GameObject child)
		{
			m_Children.Remove(this);
		}

		public void SetPosition(float x, float y)
		{
	
		}

		public void GetPosition()
		{
		}

		public void SetRotation(float rotate)
		{
			
			//m_LocalTransform = m_LocalTransform.SetRotateZ(rotate);
		}

		public void GetRotation()
		{

		}

		public void SetScale(float x, float y)
		{
			m_scale.m1 = x;
			m_scale.m5 = y;
		}

		public Vector2 GetScale(Matrix3 scale)
		{
			Vector2 Scale;
			Scale.x = scale.m1;
			Scale.y = scale.m5;

			return Scale;
		}
		
		public void Update(float deltatime)
		{
		}

		public void UpdateTransforms()
		{
			if (m_Parent != null)
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			else
				m_GlobalTransform = m_LocalTransform;

			foreach (GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}

		public void OnCollision()
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
