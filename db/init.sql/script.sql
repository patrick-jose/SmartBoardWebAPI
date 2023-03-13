--
-- PostgreSQL database cluster dump
--

-- Started on 2023-03-13 06:23:47

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Roles
--

CREATE ROLE postgres;
ALTER ROLE postgres WITH SUPERUSER INHERIT CREATEROLE CREATEDB LOGIN REPLICATION BYPASSRLS PASSWORD 'SCRAM-SHA-256$4096:PqlPerVuEkg0nmAe5iazvA==$6jtNaIqbKPxWQbZ82r/B4YuvkkxHsxLVgfsg/3N/0YY=:0A7QDbguJkFR6rF4oJyiIw9i697y1JAjVF8QKJjyINE=';

--
-- User Configurations
--








--
-- Databases
--

--
-- Database "template1" dump
--

\connect template1

--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2 (Debian 15.2-1.pgdg110+1)
-- Dumped by pg_dump version 15.2

-- Started on 2023-03-13 06:23:47

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

-- Completed on 2023-03-13 06:23:48

--
-- PostgreSQL database dump complete
--

--
-- Database "postgres" dump
--

\connect postgres

--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2 (Debian 15.2-1.pgdg110+1)
-- Dumped by pg_dump version 15.2

-- Started on 2023-03-13 06:23:48

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

-- Completed on 2023-03-13 06:23:48

--
-- PostgreSQL database dump complete
--

--
-- Database "smarboarddb" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2 (Debian 15.2-1.pgdg110+1)
-- Dumped by pg_dump version 15.2

-- Started on 2023-03-13 06:23:48

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3383 (class 1262 OID 16388)
-- Name: smarboarddb; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE smarboarddb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE smarboarddb OWNER TO postgres;

\connect smarboarddb

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 224 (class 1259 OID 16421)
-- Name: board; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.board (
    id integer NOT NULL,
    name character varying NOT NULL,
    active boolean NOT NULL
);


ALTER TABLE public.board OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16420)
-- Name: board_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.board_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.board_id_seq OWNER TO postgres;

--
-- TOC entry 3384 (class 0 OID 0)
-- Dependencies: 223
-- Name: board_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.board_id_seq OWNED BY public.board.id;


--
-- TOC entry 215 (class 1259 OID 16390)
-- Name: comment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment (
    id integer NOT NULL,
    taskid integer NOT NULL,
    writerid integer NOT NULL,
    content character varying NOT NULL,
    datecreation date NOT NULL
);


ALTER TABLE public.comment OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16389)
-- Name: comment_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comment_id_seq OWNER TO postgres;

--
-- TOC entry 3385 (class 0 OID 0)
-- Dependencies: 214
-- Name: comment_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comment_id_seq OWNED BY public.comment.id;


--
-- TOC entry 222 (class 1259 OID 16414)
-- Name: section; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.section (
    id integer NOT NULL,
    name character varying NOT NULL,
    boardid integer NOT NULL,
    active boolean NOT NULL
);


ALTER TABLE public.section OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16413)
-- Name: section_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.section_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.section_id_seq OWNER TO postgres;

--
-- TOC entry 3386 (class 0 OID 0)
-- Dependencies: 221
-- Name: section_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.section_id_seq OWNED BY public.section.id;


--
-- TOC entry 218 (class 1259 OID 16403)
-- Name: statushistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.statushistory (
    taskid integer NOT NULL,
    datemodified date,
    previussectionid integer,
    userid integer NOT NULL,
    actualsectionid integer
);


ALTER TABLE public.statushistory OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16397)
-- Name: task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.task (
    id integer NOT NULL,
    name character varying NOT NULL,
    description character varying,
    datecreation date NOT NULL,
    creatorid integer NOT NULL,
    sectionid integer NOT NULL,
    blocked boolean NOT NULL,
    assigneeid integer,
    "position" integer NOT NULL
);


ALTER TABLE public.task OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16396)
-- Name: task_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.task_id_seq OWNER TO postgres;

--
-- TOC entry 3387 (class 0 OID 0)
-- Dependencies: 216
-- Name: task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.task_id_seq OWNED BY public.task.id;


--
-- TOC entry 220 (class 1259 OID 16407)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    name character varying NOT NULL,
    password character varying NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16406)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_id_seq OWNER TO postgres;

--
-- TOC entry 3388 (class 0 OID 0)
-- Dependencies: 219
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- TOC entry 3204 (class 2604 OID 16424)
-- Name: board id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.board ALTER COLUMN id SET DEFAULT nextval('public.board_id_seq'::regclass);


--
-- TOC entry 3200 (class 2604 OID 16393)
-- Name: comment id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment ALTER COLUMN id SET DEFAULT nextval('public.comment_id_seq'::regclass);


--
-- TOC entry 3203 (class 2604 OID 16417)
-- Name: section id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.section ALTER COLUMN id SET DEFAULT nextval('public.section_id_seq'::regclass);


--
-- TOC entry 3201 (class 2604 OID 16400)
-- Name: task id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task ALTER COLUMN id SET DEFAULT nextval('public.task_id_seq'::regclass);


--
-- TOC entry 3202 (class 2604 OID 16410)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- TOC entry 3377 (class 0 OID 16421)
-- Dependencies: 224
-- Data for Name: board; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.board (id, name, active) FROM stdin;
\.


--
-- TOC entry 3368 (class 0 OID 16390)
-- Dependencies: 215
-- Data for Name: comment; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comment (id, taskid, writerid, content, datecreation) FROM stdin;
\.


--
-- TOC entry 3375 (class 0 OID 16414)
-- Dependencies: 222
-- Data for Name: section; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.section (id, name, boardid, active) FROM stdin;
\.


--
-- TOC entry 3371 (class 0 OID 16403)
-- Dependencies: 218
-- Data for Name: statushistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.statushistory (taskid, datemodified, previussectionid, userid, actualsectionid) FROM stdin;
\.


--
-- TOC entry 3370 (class 0 OID 16397)
-- Dependencies: 217
-- Data for Name: task; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.task (id, name, description, datecreation, creatorid, sectionid, blocked, assigneeid, "position") FROM stdin;
\.


--
-- TOC entry 3373 (class 0 OID 16407)
-- Dependencies: 220
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" (id, name, password) FROM stdin;
\.


--
-- TOC entry 3389 (class 0 OID 0)
-- Dependencies: 223
-- Name: board_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.board_id_seq', 1, false);


--
-- TOC entry 3390 (class 0 OID 0)
-- Dependencies: 214
-- Name: comment_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.comment_id_seq', 1, false);


--
-- TOC entry 3391 (class 0 OID 0)
-- Dependencies: 221
-- Name: section_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.section_id_seq', 1, false);


--
-- TOC entry 3392 (class 0 OID 0)
-- Dependencies: 216
-- Name: task_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.task_id_seq', 1, false);


--
-- TOC entry 3393 (class 0 OID 0)
-- Dependencies: 219
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 1, false);


--
-- TOC entry 3214 (class 2606 OID 16436)
-- Name: board board_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.board
    ADD CONSTRAINT board_pk PRIMARY KEY (id);


--
-- TOC entry 3206 (class 2606 OID 16428)
-- Name: comment comment_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_pk PRIMARY KEY (id);


--
-- TOC entry 3212 (class 2606 OID 16434)
-- Name: section section_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.section
    ADD CONSTRAINT section_pk PRIMARY KEY (id);


--
-- TOC entry 3208 (class 2606 OID 16430)
-- Name: task task_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_pk PRIMARY KEY (id);


--
-- TOC entry 3210 (class 2606 OID 16432)
-- Name: user user_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (id);


--
-- TOC entry 3215 (class 2606 OID 16442)
-- Name: comment comment_task_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_task_fk FOREIGN KEY (taskid) REFERENCES public.task(id);


--
-- TOC entry 3216 (class 2606 OID 16437)
-- Name: comment comment_user_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_user_fk FOREIGN KEY (writerid) REFERENCES public."user"(id);


--
-- TOC entry 3224 (class 2606 OID 16482)
-- Name: section section_board_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.section
    ADD CONSTRAINT section_board_fk FOREIGN KEY (boardid) REFERENCES public.board(id);


--
-- TOC entry 3220 (class 2606 OID 16472)
-- Name: statushistory statushistory_actual_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statushistory
    ADD CONSTRAINT statushistory_actual_fk FOREIGN KEY (actualsectionid) REFERENCES public.section(id);


--
-- TOC entry 3221 (class 2606 OID 16467)
-- Name: statushistory statushistory_previus_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statushistory
    ADD CONSTRAINT statushistory_previus_fk FOREIGN KEY (previussectionid) REFERENCES public.section(id);


--
-- TOC entry 3222 (class 2606 OID 16462)
-- Name: statushistory statushistory_task_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statushistory
    ADD CONSTRAINT statushistory_task_fk FOREIGN KEY (taskid) REFERENCES public.task(id);


--
-- TOC entry 3223 (class 2606 OID 16477)
-- Name: statushistory statushistory_user_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statushistory
    ADD CONSTRAINT statushistory_user_fk FOREIGN KEY (userid) REFERENCES public."user"(id);


--
-- TOC entry 3217 (class 2606 OID 16457)
-- Name: task task_assignee_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_assignee_fk FOREIGN KEY (assigneeid) REFERENCES public."user"(id);


--
-- TOC entry 3218 (class 2606 OID 16447)
-- Name: task task_creator_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_creator_fk FOREIGN KEY (creatorid) REFERENCES public."user"(id);


--
-- TOC entry 3219 (class 2606 OID 16452)
-- Name: task task_section_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_section_fk FOREIGN KEY (sectionid) REFERENCES public.section(id);


-- Completed on 2023-03-13 06:23:48

--
-- PostgreSQL database dump complete
--

-- Completed on 2023-03-13 06:23:48

--
-- PostgreSQL database cluster dump complete
--

