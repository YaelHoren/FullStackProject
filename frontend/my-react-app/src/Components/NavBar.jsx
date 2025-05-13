import { Link } from 'react-router-dom';

const NavBar = () => {
  return (
    <nav style={styles.nav}>
      <Link to="/" style={styles.link}>דף הבית</Link>
      <Link to="/branches" style={styles.link}>סניפים</Link>
    </nav>
  );
};

const styles = {
  nav: {
    padding: '10px',
    backgroundColor: '#f0f0f0',
    textAlign: 'center',
  },
  link: {
    margin: '0 15px',
    textDecoration: 'none',
    color: '#007BFF',
    fontSize: '18px',
  },
};

export default NavBar;