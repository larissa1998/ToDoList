import axios from "axios";
import { useState, useEffect } from "react";

const Home = () => {
  const [posts, setPosts] = useState([]);
  const [title, setTitle] = useState("");
  const [isCompleted, setIsCompleted] = useState(false);
  const [currentPost, setCurrentPost] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const apiEndPoint = "https://localhost:7105/api/Tasks";

  useEffect(() => {
    const getPosts = async () => {
      const { data: res } = await axios.get(apiEndPoint);
      setPosts(res);
    };
    getPosts();
  }, []);

  const addPost = async () => {
    const post = { title, isCompleted };
    await axios.post(apiEndPoint, post);
    setPosts([post, ...posts]);
    setTitle("");
    setIsCompleted(false);
  };

  const openEditModal = (post) => {
    setCurrentPost(post);
    setTitle(post.title);
    setIsCompleted(post.isCompleted);
    setShowModal(true);
  };

  const handleUpdate = async () => {
    const updatedPost = { ...currentPost, title, isCompleted };
    await axios.put(apiEndPoint + "/" + currentPost.id, updatedPost);
    const updatedPosts = posts.map(p => p.id === currentPost.id ? updatedPost : p);
    setPosts(updatedPosts);
    setShowModal(false);
    setTitle("");
    setIsCompleted(false);
  };

  const handleDelete = async (post) => {
    await axios.delete(apiEndPoint + "/" + post.id);
    setPosts(posts.filter((p) => p.id !== post.id));
  };

  return (
    <>
      <div className="container mt-3">
        <h2 className="mb-3">Possuem {posts.length} atividades na base</h2>
        <div className="input-group mb-3">
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            placeholder="Digite o título da atividade"
            className="form-control"
          />
          <div className="input-group-text">
            <input
              type="checkbox"
              checked={isCompleted}
              onChange={(e) => setIsCompleted(e.target.checked)}
              className="form-check-input mt-0"
            />
            <label className="form-check-label ms-2">Concluído</label>
          </div>
          <button onClick={addPost} className="btn btn-success ms-2">
            Adicionar
          </button>
        </div>
        <table className="table table-striped">
          <thead className="table-dark">
            <tr>
              <th>Titulo</th>
              <th>Status</th>
              <th>Editar</th>
              <th>Deletar</th>
            </tr>
          </thead>
          <tbody>
            {posts.map((post) => (
              <tr key={post.id}>
                <td> {post.title} </td>
                <td> {post.isCompleted ? "Sim" : "Não"} </td>
                <td>
                  <button
                    onClick={() => openEditModal(post)}
                    className="btn btn-info"
                  >
                    Editar
                  </button>
                </td>
                <td>
                  <button
                    onClick={() => handleDelete(post)}
                    className="btn btn-danger"
                  >
                    Excluir
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {showModal && (
        <div className="modal show fade" style={{ display: "block" }} tabIndex="-1">
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Editar Post</h5>
                <button type="button" className="btn-close" onClick={() => setShowModal(false)}></button>
              </div>
              <div className="modal-body">
                <input
                  type="text"
                  value={title}
                  onChange={(e) => setTitle(e.target.value)}
                  placeholder="Digite o título da atividade"
                  className="form-control mb-3"
                />
                <div className="form-check">
                  <input
                    type="checkbox"
                    checked={isCompleted}
                    onChange={(e) => setIsCompleted(e.target.checked)}
                    className="form-check-input"
                    id="completedCheck"
                  />
                  <label className="form-check-label" htmlFor="completedCheck">
                    Concluído
                  </label>
                </div>
              </div>
              <div className="modal-footer">
                <button type="button" className="btn btn-secondary" onClick={() => setShowModal(false)}>
                  Cancelar
                </button>
                <button type="button" className="btn btn-primary" onClick={handleUpdate}>
                  Salvar Alterações
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default Home;
