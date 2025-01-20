import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useContext } from "react";
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCard";
import { ContactTypeCard } from "../../components/ProspectionDetail/ContactTypeCard/ContactTypeCard";
import { VisitTypeCard } from "../../components/ProspectionDetail/VisitTypeCard/VisitTypeCard";
import { GeneralSituation } from "../../components/ProspectionDetail/GeneralSituationCard/GeneralSituationCard";
import { TextSection } from "../../components/ProspectionDetail/TextSection/TextSection";
import { CompetitorBrandList } from "../../components/ProspectionDetail/CompetitorBrandList/CompetitorBrandList";
import { BrandInterestCard } from "../../components/ProspectionDetail/BrandInterestCard/BrandInterestCard";
import styles from "./ProspectionDetail.module.css";
import { ShopDetailContext } from "../../contexts/ShopDetailContext";
import { ProspectionDetailContext } from "../../contexts/ProspectionDetailContext";
import { ToDoItem } from "../../components/ProspectionDetail/ToDo/ToDoItem";
import { BrandCard } from "../../components/ProspectionDetail/BrandCard/BrandCard";
import CustomLoader from "../../components/LoaderSpinner/CustomLoader";
import { TfiArrowTopRight } from "react-icons/tfi";

export const ProspectionDetail = () => {

  const navigate = useNavigate();

  const { shopId, prospectionId } = useParams();

  // Contexts

  const {
    setShopId,
    shopDetail,
  } = useContext(ShopDetailContext);

  const {
    setProspectionId,
    prospectionDetail,
    contactType,
    visitType,
    prospectionBrands,
    prospectionCompetitorBrands,
    prospectionBrandInterests,
    prospectionToDos
  } = useContext(ProspectionDetailContext);

  // Set shop id & prospection id
  useEffect(() => {
    if (shopId && prospectionId) {
      if (Number.isNaN(parseInt(shopId)) || Number.isNaN(parseInt(prospectionId))) {
        // If shop/prospection ids cannot be set (e.g. undefined), navigate to NotFound page
        navigate("/404");
      }
      else {
        if (!shopDetail) {
          setShopId(+shopId);
        }
        setProspectionId(+prospectionId);
      }
    }
  }, [shopId, prospectionId])

  return (
    <main className={styles.main}>

      {prospectionDetail &&
        <>
          <h1 className={styles.h1}>
            Prospectie<wbr></wbr> ({new Date(prospectionDetail!.visitDate).toLocaleDateString()})
          </h1>

          {shopDetail && <ShopDetailCard shop={shopDetail} />}

          {/* Info contact & visit */}

          <h2 className={styles.sectionTitle}>Info</h2>

          <section className={styles.section}>
            {contactType && prospectionDetail && (
              <ContactTypeCard contactType={contactType} contactPersonName={prospectionDetail.contactName} contactEmail={prospectionDetail.contactEmail} contactPhone={prospectionDetail.contactPhone} />
            )}
            {visitType && prospectionDetail && <VisitTypeCard visitType={visitType} visitContext={prospectionDetail?.visitContext} />}
          </section>

          {/* FC70 Brands */}

          <h2 className={styles.sectionTitle}>FC70 Brands</h2>

          {prospectionBrands.length > 0 &&
            <section className={styles.sectionList}>
              {prospectionBrands.map((brand, index) => {
                return (
                  <article key={index}>
                    <BrandCard prospectionBrand={brand} brandName={brand.brandName} />
                  </article>
                );
              })}
            </section>}

          {prospectionBrands.length < 1 &&
            <section className={styles.section}>
              <p className={styles.marginZero}>Geen FC70 brands.</p>
            </section>}

          {/* Andere merken */}

          <h2 className={styles.sectionTitle}>Andere merken</h2>

          <section className={styles.section}>
            <CompetitorBrandList prospectionCompetitorBrands={prospectionCompetitorBrands} />

            <TextSection title="Nieuwe Merken" text={prospectionDetail.newBrands} />
          </section>

          {/* General situation */}

          <h2 className={styles.sectionTitle}>Algemene situatie</h2>

          <section className={styles.section}>
            {prospectionDetail && <GeneralSituation detail={prospectionDetail} />}
          </section>

          {/* Brand interests */}

          <h2 className={styles.sectionTitle}>FC70 interesses</h2>

          {prospectionBrandInterests.length > 0 &&
            <section className={styles.sectionList}>
              {prospectionBrandInterests.map((brand, index) =>
                <article key={index}>
                  <BrandInterestCard brand={brand} index={index} />
                </article>
              )}
            </section>
          }

          {prospectionBrandInterests.length < 1 &&
            <section className={styles.section}>
              <p className={styles.marginZero}>Geen interesses.</p>
            </section>}

          {/* Feedback */}

          <h2 className={styles.sectionTitle}>Feedback</h2>

          <section className={styles.section}>
            <TextSection title="Trends en noden in de markt" text={prospectionDetail?.trends} />
            <TextSection title="Extra opmerkingen en feedback" text={prospectionDetail?.extra} />
          </section>

          {/* ToDos */}

          <h2 className={styles.sectionTitle}>Opvolging</h2>

          {prospectionToDos.length > 0 &&
            <section className={styles.sectionList}>
              {prospectionToDos.map((x, index) => (
                <ToDoItem key={index} todo={x} />
              ))}
            </section>}

          {prospectionToDos.length < 1 &&
            <section className={styles.section}>
              <p className={styles.marginZero}>Geen taken voor opvolging.</p>
            </section>}

          <button
            className={styles.link_button}
            onClick={() => navigate(`/shop/${shopId}/prospections`)}>
            Terug naar overzicht
            <TfiArrowTopRight className={styles.link_button__icon} />
          </button>
        </>
      }

      {!prospectionDetail &&
        <div className={styles.loading}>
          <p>Prospectie wordt geladen...</p>
          <CustomLoader />
        </div>}
    </main>
  );
};
