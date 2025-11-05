import "../styles/cards.css";

export default function Card({ title, children }) {
  return (
    <div className="card">
      <h3>{title}</h3>
      {children && <p>{children}</p>}
    </div>
  );
}